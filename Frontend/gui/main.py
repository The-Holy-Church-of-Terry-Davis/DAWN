#!/usr/bin/env python3

import tkinter as tk


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
            self.working_frame, text="MyProject", font=("Arial", 30), justify="left"
        )

        projName = tk.Entry(
            self.working_frame, textvariable="hi", width=16, font=("Arial", 30)
        )
        projSubmit = tk.Button(
            self.working_frame,
            text="Submit",
            width=10,
            height=2,
            command=self.displayProjName,
            anchor="w"
        )

        # projName.pack(side=tk.LEFT)
        # projSubmit.pack(side=tk.LEFT, padx=(5, 5))

        projNameLabel.grid(column=0, row=0, padx=(0, 120), pady=(0, 10))
        
        projName.grid(column=0, row=1)
        projSubmit.grid(column=1, row=1, padx=10)

        self.working_frame.pack(side="top", pady=(25, 0))
    
    def displayProjName(self):
        projNameString = projName.get()
        projNameLabel.configure(text=projNameString)

    """
    import tkinter as tk

    root = tk.Tk()

    b1 = tk.Button(root, text='b1')
    b2 = tk.Button(root, text='b2')
    b1.grid(column=0, row=0)   # grid dynamically divides the space in a grid
    b2.grid(column=1, row=0)   # and arranges widgets accordingly
    root.mainloop()

    
    using pack:

    import tkinter as tk

    root = tk.Tk()

    b1 = tk.Button(root, text='b1')
    b2 = tk.Button(root, text='b2')
    b1.pack(side=tk.LEFT)      # pack starts packing widgets on the left 
    b2.pack(side=tk.LEFT)      # and keeps packing them to the next place available on the left
    root.mainloop()

    """

    """
    def main(self):
        self.working_frame.destroy()
        self.working_frame = ttk.Frame(self, width=300, height=150, relief='groove')
        self.working_frame.pack_propagate(False)
        ttk.Label(self.working_frame, text='This is window 1').pack(side='top', pady=(25, 25))
        self.working_frame.pack(side='top', pady=(25, 0))
    """


if __name__ == "__main__":
    App().mainloop()
