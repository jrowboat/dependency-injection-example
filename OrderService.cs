
public class OrderService : IOrderService {
        private readonly ICustomerEventService _customerEventService;
        private readonly ILogCreator _logCreator;
        private readonly ICartAccessor _cartAccessor;
        private readonly ICustomerService _customerService;
        private readonly IOrderAccessor _orderAccessor;
        private readonly IOrderRecordAccessor _orderRecordAccessor;
        private readonly IOrderRecordHelper _orderRecordHelper;

        public OrderService (ICustomerEventService customerEventService, ILogCreator logCreator, ICartAccessor cartAccessor, ICustomerService customerService, 
            IOrderAccessor orderAccessor, IOrderRecordAccessor orderRecordAccessor, IOrderRecordHelper orderRecordHelper, ITransactionManager transactionManager)
        {
            _customerEventService = customerEventService;
            _logCreator = logCreator;
            _cartAccessor = cartAccessor;
            _customerService = customerService;
            _orderAccessor = orderAccessor;
            _orderRecordAccessor = orderRecordAccessor;
            _orderRecordHelper = orderRecordHelper;
            _transactionManager = transactionManager;
        }

        public async Task<PlaceOrderResponse> PlaceOrder(Order order){
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