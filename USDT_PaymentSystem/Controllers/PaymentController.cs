using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USDT_PaymentSystem.Models;

namespace USDT_PaymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TronService _tronService;

        public PaymentController(ApplicationDbContext context, TronService tronService)
        {
            _context = context;
            _tronService = tronService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            return await _context.Invoices.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null) return NotFound("الفاتورة غير موجودة");
            return invoice;
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> CreateInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, invoice);
        }

        [HttpPost("verify/{id}")]
        public async Task<IActionResult> VerifyPayment(int id, [FromBody] string txHash)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
                return NotFound("الفاتورة غير موجودة.");

            if (invoice.Status == "Paid")
                return BadRequest("هذه الفاتورة تم دفعها وإغلاقها بالفعل.");

            var existingTx = await _context.Invoices.AnyAsync(i => i.TransactionId == txHash);
            if (existingTx)
                return BadRequest("رقم المعاملة هذا تم استخدامه مسبقاً لدفعة أخرى!");

            var isPaid = await _tronService.VerifyTransactionAsync(txHash, invoice.WalletAddress, invoice.Amount);

            if (isPaid)
            {
                invoice.Status = "Paid";
                invoice.TransactionId = txHash;
                await _context.SaveChangesAsync();
                return Ok(new { message = "تم التأكد من الدفع بنجاح وتحديث الفاتورة!", invoice });
            }

            return BadRequest("لم يتم العثور على المعاملة أو أنها غير مطابقة لشروط الفاتورة.");
        }
    }
}