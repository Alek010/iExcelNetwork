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

  ![image](https://github.com/Alek010/iExcelNetwork/assets/77459555/d3dd18b1-2b6d-475e-8daa-be7bb63859fe)

## Install
* Download a zip file *iExcelNetwork_PoC_ver_1.zip*. The zip file is included in release [files](https://github.com/Alek010/iExcelNetwork/releases/tag/v1.0.0-poc)
* The zip file's sha256 is 4725336befd9aea96d47708b98ebc990c197dee522140b5a8b5bfd130e0f1805.
* Extract.
* Install iExcelNetwork by executing setup.exe.

## How It Works
* Press the "How it Works" button to see instructions on how to use iExcelNetwork.
* A new Excel sheet named "How It Works" will open.

![image](https://github.com/Alek010/iExcelNetwork/assets/77459555/d30e56f4-00fd-47bc-8330-e345deb9df26)


## Build Network
* Select a range and press the "Build Network" button.
* An HTML file named visjs_network.html will be generated in the user's temp folder.
* The HTML file will open in your preferred browser.

![image](https://github.com/Alek010/iExcelNetwork/assets/77459555/36785bac-e14d-4cc3-bcd9-c17d4530c0ce)
