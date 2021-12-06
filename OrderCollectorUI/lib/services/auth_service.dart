import 'dart:async';
import 'dart:convert';
import 'dart:html';

import 'package:flutter/cupertino.dart';
import 'package:http/http.dart' as http;
import 'package:order_collector_ui/views/collect_list.dart';
import 'package:order_collector_ui/views/login.dart';
import 'package:order_collector_ui/models/login.dart';

class AuthService {
  final Storage _localStorage = window.localStorage;

  StreamController<bool> authStatus = StreamController<bool>();

  handleSession() {
    return StreamBuilder(
      stream: authStatus.stream,
      builder: (BuildContext context, snapshot) {
        print('muuttui stream');
        if (snapshot.hasData) {
          return CollectListPage();
        } else {
          return LoginPage();
        }
      },
    );
  }

  signIn(Login login) async {
    final body = json.encode(login.toJSON());

    final response = await http.post(
        Uri.parse('https://localhost:7163/api/Authetication/login'),
        headers: {"Content-Type": "application/json"},
        body: body);

    if (response.statusCode == 200) {
      await storeAuthToken(response.body);
      authStatus.add(true);
      return true;
    } else {
      authStatus.add(false);
      return false;
    }
  }

  logOut() {
    _localStorage.remove('authToken');
  }

  register(Login login) async {
    final response = await http.post(
        Uri.parse('https://localhost:7163/api/User/register'),
        headers: {"Content-Type": "application/json"},
        body: login.toJSON());

    if (response.statusCode == 200 && response.body == 'true') {
      await signIn(login);
      return true;
    } else {
      return false;
    }
  }

  storeAuthToken(String token) async {
    _localStorage['authToken'] = token;
  }
}
