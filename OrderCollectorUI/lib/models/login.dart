class Login {
  String email;
  String password;

  Login(this.email, this.password);

  Map<String, dynamic> toJSON() => {'email': email, 'password': password};
}
