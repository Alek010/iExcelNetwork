# iExcelNetwork
iExcelNetwork is an Excel VSTO add-in written in C# designed to build network visualizations using the [vis.js](https://visjs.org) network library.

The iExcelNetwork does not require an internet connection and does not send data outside the local machine to build the network.

## iExcelNetwork Proof of Concept (PoC)
The current PoC has basic functionality:
* Select a range.
* Save the range as a JSON file.
* Build a network based on the selected range.
  
The capabilities of the iExecNetwork PoC can be extended. [See](https://visjs.github.io/vis-network/examples/) Vis.js Network examples.

![image](https://github.com/user-attachments/assets/f8df1dae-a51f-4733-8754-db6b6c5d570c)



## Install
* Download a zip file *iExcelNetwork_PoC_ver_1_2_1.zip*. The zip file is included in release.
* The zip file's sha256 is 301d3fa9243f2c565039f0c36d5025af348622681e8c0a41ee0ec780e8161738.
* Extract.
* Install iExcelNetwork by executing setup.exe.

## How It Works
* Press the "How it Works" button to see instructions on how to use iExcelNetwork.
* A new Excel sheet named "How It Works" will open.

## Build Network
![image](https://github.com/user-attachments/assets/fcdda860-ba63-45a8-b449-f4b5ce22091d)


* Select a range and press the "Build Network" button.
* **Note!!!** that columns names should to be *from* and *to*. Another acepted range is with column names are *from, to, count*. It is possible to have duplicates.
* An HTML file named iExcelnetwork.html will be generated in the user's temp folder.
* The HTML file will open in your default browser.
  
![image](https://github.com/Alek010/iExcelNetwork/assets/77459555/29dfaad0-e848-4484-bac6-97a0b5b5db4e)

### Network Properties Button
* Set direction of thearrow.
* Set HTML file's name and output folder.
  
![image](https://github.com/Alek010/iExcelNetwork/assets/77459555/d822f198-582c-4a1a-91ea-d82d25e7a49c)

### Network Analytics
#### Find All Directed path : 
* Press button when data range A1:B8 is selected.

![image](https://github.com/user-attachments/assets/79126da6-7d4f-4d6c-a1af-a24459b9be8e)

* If your source node is A and your destination node is C, press "Find" to generate the result.

![image](https://github.com/user-attachments/assets/296563ae-d579-44b8-9832-9ac045f3945a)

* If your source node is C and your destination node is A, you will receive a message indicating that no path was found.
* Similarly, if you attempt to find a path between nodes F and A, no path will be found due to the direction of the connections: F -> B <- A.

## Next step
Implement all paths find as non directional edges to find path from F to A as F -> B <- A.
