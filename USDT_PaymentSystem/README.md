# 🚀 USDT (TRC20) Payment Gateway (.NET 8)

بوابة دفع إلكترونية متكاملة للعملات الرقمية (USDT - TRC20) مبنية باستخدام .NET 8 و EF Core، وتعتمد على الاتصال المباشر بشبكة TRON البلوكشين للتحقق من المعاملات.

---

## 🛠️ التقنيات المستخدمة (Tech Stack)

* **Backend**: .NET 8.0 Web API
* **Database**: Entity Framework Core & SQL Server
* **Blockchain Integration**: TronGrid API
* **Frontend**: JavaScript (Vanilla JS / Auto-Polling), HTML5, CSS3, QRCode.js

---

## ✨ المميزات الرئيسية (Key Features)

* **توليد الفواتير الديناميكية**: إنشاء فاتورة بمبلغ محدد وعرض عنوان المحفظة مع رمز QR ملائم.
* **الفحص التلقائي (Auto-Polling)**: تقوم الواجهة بفحص حالة الدفع كل 5 ثوانٍ تلقائياً ودون الحاجة لتحديث الصفحة.
* **الحماية من الدفع الوهمي**: التحقق المباشر من الـ TX Hash والمبلغ والمحفظة المستقبلة عبر شبكة TRON قبل تغيير حالة الفاتورة.
* **التحويل التلقائي**: توجيه العميل لصفحة نجاح الشراء فور اكتمال عملية الدفع.

---

## 🚀 كيفية التشغيل محلياً (How to Run)

1. قم بعمل `Clone` للمستودع:
   ```bash
   git clone [https://github.com/YourUsername/YourRepository.git](https://github.com/YourUsername/YourRepository.git)