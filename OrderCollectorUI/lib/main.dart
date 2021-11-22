// Copyright 2018 The Flutter team. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

import 'dart:async';
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:intl/intl.dart';

Future<Order> FetchOrderById(int orderId) async {
  final response = await http
      .get(Uri.parse('https://localhost:7163/Order/GetOrderById/$orderId'));

  if (response.statusCode == 200) {
    // If the server did return a 200 OK response,
    // then parse the JSON.
    return Order.fromJson(jsonDecode(response.body));
  } else {
    // If the server did not return a 200 OK response,
    // then throw an exception.
    throw Exception('Failed to load order');
  }
}

Future<List<Order>> FetchCollectOrderList() async {
  final response = await http
      .get(Uri.parse('https://localhost:7163/Order/GetUncollectedOrders'));

  if (response.statusCode == 200) {
    // If the server did return a 200 OK response,
    // then parse the JSON.
    return parseOrderList(response.body);
  } else {
    // If the server did not return a 200 OK response,
    // then throw an exception.
    throw Exception('Failed to load order');
  }
}

// A function that converts a response body into a List<Photo>.
List<Order> parseOrderList(String responseBody) {
  final parsed = jsonDecode(responseBody).cast<Map<String, dynamic>>();

  return parsed.map<Order>((json) => Order.fromJson(json)).toList();
}

class Order {
  final int Id;
  final int OrderId;
  final int CustomerId;
  final String CustomerName;
  final String InvoiceAddress;
  final String DeliveryAddress;
  final DateTime DeliveryDate;
  final String SellerName;
  final String OrderComment;
  final double OrderPrice;
  final bool Collected;
  //final OrderRow[] OrderRows

  Order({
    required this.Id,
    required this.OrderId,
    required this.CustomerId,
    required this.CustomerName,
    required this.InvoiceAddress,
    required this.DeliveryAddress,
    required this.DeliveryDate,
    required this.SellerName,
    required this.OrderComment,
    required this.OrderPrice,
    required this.Collected,
  });

  factory Order.fromJson(Map<String, dynamic> json) {
    return Order(
      Id: json['id'],
      OrderId: json['orderId'],
      CustomerId: json['customerId'],
      CustomerName: json['customerName'],
      InvoiceAddress: json['invoiceAddress'],
      DeliveryAddress: json['deliveryAddress'],
      DeliveryDate: DateTime.parse(json['deliveryDate']),
      SellerName: json['sellerName'],
      OrderComment: json['orderComment'],
      OrderPrice: json['orderPrice'],
      Collected: json['collected'],
    );
  }
}

void main() => runApp(const OrderCollectorApp());

class OrderCollectorApp extends StatelessWidget {
  const OrderCollectorApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    const appTitle = 'OrderCollector v1';

    return const MaterialApp(
      title: appTitle,
      home: UncollectedOrdersPage(
        title: appTitle,
      ),
    );
  }
}

class UncollectedOrdersPage extends StatelessWidget {
  const UncollectedOrdersPage({Key? key, required this.title})
      : super(key: key);

  final String title;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(title),
      ),
      body: FutureBuilder<List<Order>>(
        future: FetchCollectOrderList(),
        builder: (context, snapshot) {
          if (snapshot.hasError) {
            return const Center(
              child: Text('An error has occurred!'),
            );
          } else if (snapshot.hasData) {
            return OrderList(orders: snapshot.data!);
          } else {
            return const Center(
              child: CircularProgressIndicator(),
            );
          }
        },
      ),
    );
  }
}

class OrderList extends StatelessWidget {
  const OrderList({Key? key, required this.orders}) : super(key: key);

  final List<Order> orders;

  @override
  Widget build(BuildContext context) {
    return ListView.builder(
      padding: const EdgeInsets.all(16),
      itemCount: orders.length,
      itemBuilder: (context, i) {
        if (i.isOdd) {
          //return Divider();
        }

        final int index = 1 ~/ 2;

        if (index >= orders.length) {
          //throw Error();
        }

        return _buildRow(orders[i]);
      },
    );
  }

  Widget _buildRow(Order order) {
    return ListTile(title: Text(order.Id.toString()+ ' | ' + order.CustomerName), trailing: Text(DateFormat("d.M.yyyy").format(order.DeliveryDate)));
  }
}