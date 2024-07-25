# iExcelNetwork
iExcelNetwork is an Excel VSTO add-in written in C# designed to build network visualizations using the [vis.js](https://visjs.org) network library.

The iExcelNetwork does not require an internet connection and does not send data outside the local machine to build the network.

## iExcelNetwork Proof of Concept (PoC)
The current PoC has basic functionality:
* Select a range.
* Save the range as a JSON file.
* Build a network based on the selected range.
* The generated network is a basic example using Vis.js Network.
  
The capabilities of the iExecNetwork PoC can be extended. [See](https://visjs.github.io/vis-network/examples/) Vis.js Network examples.

![image](https://github.com/Alek010/iExcelNetwork/assets/77459555/609f1724-d722-495a-ab78-2412e981015e)


## Install
* Download a zip file *iExcelNetwork_PoC_ver_1_1_0.zip*. The zip file is included in release.
* The zip file's sha256 is ff8e3dbd8b646395f039f0a71d87a38ef280c76230a712e7cac5349dc0aab309.
* Extract.
* Install iExcelNetwork by executing setup.exe.

## How It Works
* Press the "How it Works" button to see instructions on how to use iExcelNetwork.
* A new Excel sheet named "How It Works" will open.

## Build Network
![image](https://github.com/Alek010/iExcelNetwork/assets/77459555/a76e10cf-584b-43ef-a68a-f5e8775a2192)

* Select a range and press the "Build Network" button.
* An HTML file named iExcelnetwork.html will be generated in the user's temp folder.
* The HTML file will open in your default browser.
  
![image](https://github.com/Alek010/iExcelNetwork/assets/77459555/29dfaad0-e848-4484-bac6-97a0b5b5db4e)

### Network Properties Button
* Set direction of thearrow.
* Set HTML file's name and output folder.
  
![image](https://github.com/Alek010/iExcelNetwork/assets/77459555/d822f198-582c-4a1a-91ea-d82d25e7a49c)


