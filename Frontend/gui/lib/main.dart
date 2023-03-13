import 'dart:io';
import 'dart:core';
import 'dart:ui';
import 'package:flutter/material.dart';
import 'homepage.dart';
import 'package:window_size/window_size.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  if (Platform.isWindows || Platform.isLinux || Platform.isMacOS) {
    setWindowTitle("Create DAWN App");
    setWindowMaxSize(const Size(600, 600));
    setWindowMinSize(const Size(500, 500));

    double width = window.physicalSize.width;
    double height = window.physicalSize.height;

    Rect frame = Offset(width / 2 + 150, height / 2) & const Size(1.0, 1.0);
    setWindowFrame(frame);
  }
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      title: "DAWN GUI",
      debugShowCheckedModeBanner: false,
      home: HomePage(),
    );
  }
}
