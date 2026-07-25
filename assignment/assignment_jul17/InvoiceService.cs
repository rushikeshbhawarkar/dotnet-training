using ShopEaseApp.Models;

namespace ShopEaseApp.Services
{
    public class InvoiceService
    {
        private const string InvoiceFolder = "Invoices";

        public string GenerateInvoiceText(Order order)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("=========================================");
            sb.AppendLine("            ShopEase - INVOICE");
            sb.AppendLine("=========================================");
            sb.AppendLine($"Order Id      : {order.OrderId}");
            sb.AppendLine($"Date          : {order.Date:dd-MMM-yyyy HH:mm}");
            sb.AppendLine($"Customer Name : {order.CustomerName}");
            sb.AppendLine($"Address       : {order.ShippingAddress}");
            sb.AppendLine("-----------------------------------------");
            sb.AppendLine("Items:");
            foreach (var item in order.Items)
                sb.AppendLine($"  {item}");
            sb.AppendLine("-----------------------------------------");
            sb.AppendLine($"Total Quantity : {order.TotalQuantity}");
            sb.AppendLine($"Subtotal       : Rs.{order.Total:0.00}");
            sb.AppendLine($"Discount       : Rs.{order.Discount:0.00}");
            sb.AppendLine($"GST (18%)      : Rs.{order.Gst:0.00}");
            sb.AppendLine($"Grand Total    : Rs.{order.GrandTotal:0.00}");
            sb.AppendLine("-----------------------------------------");
            sb.AppendLine($"Payment Method : {order.PaymentMethod}");
            sb.AppendLine($"Payment Status : {order.PaymentStatus}");
            sb.AppendLine($"Order Status   : {order.Status}");
            sb.AppendLine("=========================================");
            sb.AppendLine("        Thank you for shopping with us!");
            sb.AppendLine("=========================================");
            return sb.ToString();
        }

        // Simulates "downloading" the invoice by writing it to a local file.
        public string SaveInvoiceToFile(Order order)
        {
            Directory.CreateDirectory(InvoiceFolder);
            string path = Path.Combine(InvoiceFolder, $"Invoice_Order{order.OrderId}.txt");
            File.WriteAllText(path, GenerateInvoiceText(order));
            return Path.GetFullPath(path);
        }
    }
}
