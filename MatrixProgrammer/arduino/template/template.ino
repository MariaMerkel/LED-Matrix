#include <Adafruit_NeoPixel.h>

Adafruit_NeoPixel pixels (256, 6, NEO_GRB + NEO_KHZ800);

void setup() {
  pixels.begin();
  pixels.clear();

##CODEPLACEHOLDER##

  pixels.show();
}

void loop() {
}
