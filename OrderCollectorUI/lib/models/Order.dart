
// class Order {
//   final int Id;
//   final int OrderId;
//   final int CustomerId;
//   final String CustomerName;
//   final String InvoiceAddress;
//   final String DeliveryAddress;
//   final DateTime DeliveryDate;
//   final String SellerName;
//   final String OrderComment;
//   final double OrderPrice;
//   final bool Collected;
//   //final OrderRow[] OrderRows

//   Order({
//     required this.Id,
//     required this.OrderId,
//     required this.CustomerId,
//     required this.CustomerName,
//     required this.InvoiceAddress,
//     required this.DeliveryAddress,
//     required this.DeliveryDate,
//     required this.SellerName,
//     required this.OrderComment,
//     required this.OrderPrice,
//     required this.Collected,
//   });

//     factory Order.fromJson(Map<String, dynamic> json) {
//     return Order(
//       Id: json['id'],
//       OrderId: json['orderId'],
//       CustomerId: json['customerId'],
//       CustomerName: json['customerName'],
//       InvoiceAddress: json['invoiceAddress'],
//       DeliveryAddress: json['deliveryAddress'],
//       DeliveryDate: DateTime.parse(json['deliveryDate']),
//       SellerName: json['sellerName'],
//       OrderComment: json['orderComment'],
//       OrderPrice: json['orderPrice'],
//       Collected: json['collected'],
//     );
//   }

// List<Order> parseOrderList(String responseBody) {
//   final parsed = jsonDecode(responseBody).cast<Map<String, dynamic>>();

//   return parsed.map<Order>((json) => Order.fromJson(json)).toList();
// }