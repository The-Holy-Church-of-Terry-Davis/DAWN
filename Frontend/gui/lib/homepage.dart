import 'package:flutter/material.dart';

/*
TO-DO

Update cli.py to take in args and write to a log

make the log area actually read from a file and display its contents

*/

class HomePage extends StatefulWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  // gets what the user typed in the text field
  final _textController = TextEditingController();

  // for platform type
  int selected = 0;

  // store the running OS
  String runningOS = "Operating system to run on: Windows";

  // store user text input into a var
  String projectName = "MyDawnApp";

  Widget customRadio(String text, int index) {
    return OutlinedButton(
      onPressed: () {
        setState(() {
          if (index == 0) {
            selected = 1;
          } else {
            selected = 0;
          }
          runningOS = "Operating system to run on: $text";
        });
      },
      style: OutlinedButton.styleFrom(
          minimumSize: const Size(225, 45),
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(5),
            side: const BorderSide(
              color: Colors.white,
            ),
          ),
          side: const BorderSide(
            color: Colors.white,
          )),
      child: Text(
        text,
        style: TextStyle(
          color: (selected == index) ? Colors.grey.shade700 : Colors.white,
          fontSize: 15,
        ),
      ),
    );
  }

  /*
  ################################
  ################################
  #### MAIN BUILD METHOD #########
  ################################
  ################################
  */
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      // the main thing, put all the content in here
      body: Column(children: [
        namingMethod(),
        Container(
          padding: const EdgeInsets.fromLTRB(20, 25, 0, 0),
          alignment: Alignment.topLeft,
          child: Text(
            runningOS,
            style: const TextStyle(
              color: Colors.white,
              fontSize: 20,
            ),
          ),
        ),
        buttonMethod(),
        const Padding(padding: EdgeInsets.only(top: 10)),
        logArea(),
        const Spacer(), // moves the create button to the bottom
        createButton(),
      ]),
      backgroundColor: const Color.fromARGB(255, 20, 20, 20),
    );
  }

  Container logArea() {
    return Container(
      height: 150,
      width: 445,
      decoration: BoxDecoration(
        border: Border.all(
          color: Colors.white,
        ),
        borderRadius: BorderRadius.circular(5),
      ),
      child: SingleChildScrollView(
        padding: const EdgeInsets.all(10),
        scrollDirection: Axis.vertical,
        child: Text(
          // ignore: prefer_interpolation_to_compose_strings
          "Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, Log text here, ",
          style: TextStyle(
            color: Colors.grey.shade700,
          ),
        ),
      ),
    );
  }

  /*
  Padding logArea() {
    return Padding(
      padding: const EdgeInsets.fromLTRB(20, 10, 20, 0),
      child: TextButton(
        style: TextButton.styleFrom(
          minimumSize: const Size(500, 158),
          backgroundColor: const Color.fromARGB(255, 15, 15, 15),
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(5),
            side: const BorderSide(
              color: Colors.white,
            ),
          ),
        ),
        onPressed: () {},
        // ignore: prefer_const_constructors
        child: Text(
          "text here",
          style: TextStyle(
            color: Colors.grey.shade700,
            fontWeight: FontWeight.normal,
          ),
        ),
      ),
    );
  }
*/

  Padding createButton() {
    return Padding(
      padding: const EdgeInsets.fromLTRB(20, 10, 20, 20),
      child: TextButton(
        style: TextButton.styleFrom(
          minimumSize: const Size(500, 50),
          backgroundColor: Colors.green.shade900,
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(5),
            side: BorderSide(
              color: Colors.green.shade900,
            ),
          ),
          textStyle: const TextStyle(
            fontSize: 20,
          ),
        ),
        onPressed: () {},
        child: const Text(
          "Create DAWN App",
          style: TextStyle(color: Colors.white),
        ),
      ),
    );
  }

  Padding buttonMethod() {
    return Padding(
      padding: const EdgeInsets.only(top: 20),
      child: Center(
        child: Row(
          children: [
            const SizedBox(width: 20),
            customRadio("Windows", 1),
            const SizedBox(width: 10),
            customRadio("Linux", 0),
            const SizedBox(width: 20),
          ],
        ),
      ),
    );
  }

  Padding namingMethod() {
    return Padding(
      padding: const EdgeInsets.fromLTRB(20, 0, 20, 0),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.start,
        children: [
          // display text
          Padding(
            padding: const EdgeInsets.only(bottom: 20),
            child: Container(
              alignment: Alignment.topLeft,
              child: Text(projectName.replaceAll(" ", ""),
                  style: const TextStyle(
                    fontSize: 35,
                    color: Colors.white,
                  )),
            ),
          ),

          // text input
          TextField(
            controller: _textController,
            cursorColor: Colors.grey.shade200,
            style: (const TextStyle(
              color: Colors.white,
            )),
            decoration: InputDecoration(
              hintText: "MyDawnApp",
              hintStyle: TextStyle(color: Colors.grey.shade600),
              prefixIcon: Padding(
                padding: const EdgeInsets.only(left: 5),
                child: Row(
                  mainAxisSize: MainAxisSize.min,
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: const [
                    Text(
                      "Project Name: ",
                      style: TextStyle(
                        color: Colors.grey,
                        fontWeight: FontWeight.w400,
                      ),
                    ),
                  ],
                ),
              ),
              suffixIcon: IconButton(
                onPressed: () {
                  setState(() {
                    projectName = _textController.text;
                  });
                },
                icon: Icon(
                  Icons.check_rounded,
                  color: Colors.grey.shade300,
                ),
              ),
              enabledBorder: OutlineInputBorder(
                  borderSide: BorderSide(color: Colors.grey.shade300)),
              focusedBorder: OutlineInputBorder(
                  borderSide: BorderSide(color: Colors.grey.shade300)),
            ),
          ),
        ],
      ),
    );
  }
}
