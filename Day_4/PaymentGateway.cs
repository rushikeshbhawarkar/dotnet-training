using System;
public interface PaymentGateway
{
    void ProcessPayment(decimal amount);
}