﻿using GeekShopping.MessageBus;

namespace GeekShopping.OrderAPI.Messages;

public class PaymentVO : BaseMessage
{
    public long OrderId { get; set; }
    public string Name { get; set; }
    public string CartNumber { get; set; }
    public string CVV { get; set; }
    public string ExprityMonthYear { get; set; }
    public decimal PurchaseAmount { get; set; }
    public string Email { get; set; }
}
