# LED Matrix Driver
This is a PCB design for driving 16x16 LED matrices and code generation and flashing software to convert images into firmware for the PCB.

## Usage
1. Order PCBs on a service like JLCPCB. The KiCad design files are in the kicad.zip file.
2. Solder programming (4 pin) header and LED Matrix to the PCB. If you are soldering the wire and connector that typically comes with the Matrix, you will need to flip the DIN and GND wires (the pinout of the PCB is 5V, GND, DIN when the USB C port is oriented to the left).
3. Connect an AVR ISP programmer to the programming header. The pinout is RST, MOSI, MISO, SCK.
4. Flash the Arduino bootloader via the Arduino IDE. The programmer and device need to be connected to USB ports on the same host while programming to ensure a common ground.
5. Compile the provided JetBrains Rider project. Put the compile output and arduino folder into the same root folder.
6. Run the setup.bat script in the arduino folder
7. Run the program, select an image and flash it to the device
