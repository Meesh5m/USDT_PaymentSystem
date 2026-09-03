using System;

namespace USDT_PaymentSystem.Models;

public class Invoice
{
    // 1. معرف الفاتورة في قاعدة البيانات
    public int Id { get; set; }

    // 2. عنوان محفظة USDT
    public string WalletAddress { get; set; } = string.Empty;

    // 3. المبلغ المطلوب دفعه بالـ USDT
    public decimal Amount { get; set; }

    // 4. حالة الفاتورة
    public string Status { get; set; } = "Pending";

    // 5. رقم المعاملة على البلوكتشين
    public string? TransactionId { get; set; }

    // 6. تاريخ ووقت إنشاء الفاتورة
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}