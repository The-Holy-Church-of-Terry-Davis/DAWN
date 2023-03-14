#!/usr/bin/env python3

import tkinter as tk
# import TKinterModernThemes as TKMT


"""

DEPRECEATED

"""


class App(tk.Tk):
    def __init__(self):
        super().__init__()
        self.geometry("500x500")
        self.resizable(False, False)
        self.title("DAWN GUI")
        self.working_frame = tk.Frame(self)
        self.working_frame.grid(row=0, column=0, sticky="nsew")
        self.main()

    def main(self):
        global projName
        global projNameLabel

        self.working_frame.destroy()
        self.working_frame = tk.Frame(self, width=500, height=500)
        self.working_frame.pack_propagate(False)

        projNameLabel = tk.Label(
            self.working_frame, text="MyProject", font=("Arial", 25), justify="left"
        )

        projName = tk.Entry(
            self.working_frame, textvariable="hi", width=16, font=("Arial", 30)
        )
        projSubmit = tk.Button(
            self.working_frame,
            text="Submit",
            width=10,
            height=2,
            command=self.displayProjName, # see if I can pass in arguments instead of using global
        )

        projNameLabel.grid(column=0, row=0, padx=0, pady=(0, 10), sticky="w")
        
        projName.grid(column=0, row=1)
        projSubmit.grid(column=1, row=1, padx=10)


        self.working_frame.pack(side="top", pady=15, padx=15)
    
    def displayProjName(self):
        projNameString = projName.get().replace(" ", "")
        if projNameString == "":
            projNameString = "MyDawnProject"
        projNameLabel.configure(text=projNameString)


if __name__ == "__main__":
    App().mainloop()
