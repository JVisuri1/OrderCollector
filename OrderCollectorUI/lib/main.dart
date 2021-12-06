// Copyright 2018 The Flutter team. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

import 'package:flutter/material.dart';
import './services//auth_service.dart';

void main() => runApp(const OrderCollectorApp());

class OrderCollectorApp extends StatelessWidget {
  const OrderCollectorApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: AuthService().handleSession(),
    );
  }
}
