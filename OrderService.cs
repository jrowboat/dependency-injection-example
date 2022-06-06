
public class OrderService : IOrderService {

        public OrderService ()
        {
        }

        public record OrderId(Guid id){
            public static OrderId NewId() {
                return new OrderId(Guid.NewGuid());
            }
        };

        public async Task<PlaceOrderResponse> PlaceOrder(){
            // handle fulfillment of orders from start to finish
            // - refund?
            // - new order
            // We handle the kickoff. Whatever needs to happen for the fulfillment process to start
            // - We need an order id, and an event
            Guid orderId = Guid.NewGuid();

            orderAccess.CreateOrderDetails()
            
            notifer.Notify(Events.OrderPlaced, orderId);
            
            var customer = _customerService.GetCustomer(order.CustomerId);
            var cart = _cartAccessor.GetCart(order.cartId);
            
            try {
                var placeOrderResponse = await _orderAccessor.PlaceOrder(cart, order);

                if (placeOrderResponse.Successful) {
                    var orderPlacedMessage = _customerEventService.GetOrderPlacedMessage(cart, customer, order);
                    await _customerEventService.sendMessage(orderPlacedMessage);

                    var orderRecord = _orderRecordHelper.createOrderRecord(cart, customer.name, order.Id);
                    await _orderRecordAccessor.updateOrderRecord(orderRecord);
                }
                return placeOrderResponse;
            } 
            catch (Exception placeOrderException) {
                _logCreator.logException(placeOrderException);
                return new PlaceOrderResponse {
                    Successful = false,
                    ResponseMessage = placeOrderException.message
                };
            }

        }
}