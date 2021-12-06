import 'package:flutter/material.dart';
import 'package:order_collector_ui/services/auth_service.dart';
import 'package:order_collector_ui/views/collect_list.dart';
import 'package:order_collector_ui/views/signup.dart';
import 'package:order_collector_ui/models/login.dart';

class LoginPage extends StatefulWidget {
  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final formKey = new GlobalKey<FormState>();

  Login login = Login('email', 'password');

  Color primaryColor = Color(0xFFFFC107);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Container(
            height: MediaQuery.of(context).size.height,
            width: MediaQuery.of(context).size.width,
            child: Form(key: formKey, child: _buildLoginForm())));
  }

  _buildLoginForm() {
    return Padding(
        padding: const EdgeInsets.only(left: 25.0, right: 25.0),
        child: ListView(children: [
          SizedBox(height: 75.0),
          Container(
              height: 125.0,
              width: 200.0,
              child: Stack(
                children: [
                  Text('Hello',
                      style: TextStyle(fontFamily: 'Trueno', fontSize: 60.0)),
                  Positioned(
                      top: 50.0,
                      child: Text('There',
                          style:
                              TextStyle(fontFamily: 'Trueno', fontSize: 60.0))),
                  Positioned(
                      top: 97.0,
                      left: 175.0,
                      child: Container(
                          height: 10.0,
                          width: 10.0,
                          decoration: BoxDecoration(
                              shape: BoxShape.circle, color: primaryColor)))
                ],
              )),
          SizedBox(height: 25.0),
          TextFormField(
              decoration: InputDecoration(
                  labelText: 'EMAIL',
                  labelStyle: TextStyle(
                      fontFamily: 'Trueno',
                      fontSize: 12.0,
                      color: Colors.grey.withOpacity(0.5)),
                  focusedBorder: UnderlineInputBorder(
                    borderSide: BorderSide(color: primaryColor),
                  )),
              onChanged: (value) {
                login.email = value;
              }),
          TextFormField(
              decoration: InputDecoration(
                  labelText: 'PASSWORD',
                  labelStyle: TextStyle(
                      fontFamily: 'Trueno',
                      fontSize: 12.0,
                      color: Colors.grey.withOpacity(0.5)),
                  focusedBorder: UnderlineInputBorder(
                    borderSide: BorderSide(color: primaryColor),
                  )),
              obscureText: true,
              onChanged: (value) {
                login.password = value;
              }),
          SizedBox(height: 50.0),
          GestureDetector(
            onTap: () {
              AuthService().signIn(login);
            },
            child: Container(
                height: 50.0,
                child: Material(
                    borderRadius: BorderRadius.circular(25.0),
                    shadowColor: Colors.amberAccent,
                    color: primaryColor,
                    elevation: 7.0,
                    child: Center(
                        child: Text('LOGIN',
                            style: TextStyle(
                                color: Colors.white, fontFamily: 'Trueno'))))),
          ),
          SizedBox(height: 25.0),
          Row(mainAxisAlignment: MainAxisAlignment.center, children: [
            Text('New user? Register now'),
            SizedBox(width: 5.0),
            InkWell(
                onTap: () {
                  Navigator.of(context).push(
                      MaterialPageRoute(builder: (context) => SignUpPage()));
                },
                child: Text('Register',
                    style: TextStyle(
                        color: primaryColor,
                        fontFamily: 'Trueno',
                        decoration: TextDecoration.underline)))
          ])
        ]));
  }
}
