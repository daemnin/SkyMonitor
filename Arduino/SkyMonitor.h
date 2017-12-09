#ifndef __SKY_MONITOR_H__
  #if defined(ARDUINO) && ARDUINO >= 100
    #include "Arduino.h"
  #else
    #include "WProgram.h"
  #endif
  #ifndef __LOCATION_T__
    typedef struct {
      float latitude;
      float longitude;
    } location_t;
    #define __LOCATION_T__
  #endif
  #ifndef __PACKET_T__
    typedef union {
      location_t location;
      unsigned char bytes[8];
    } packet_t;
    #define __PACKET_T__
  #endif
  #define SERIAL_BAUD_RATE 115200
  #define SS_BAUD_RATE 9600
  #define VERSION "SkyMonitor BETA 0.01"
  #define GPS_RX 5
  #define GPS_TX 4

  #define GSM_APN ""
  #define GSM_LOGIN ""
  #define GSM_PASSWORD ""

  #define API_HOST "localhost"
  #define API_PORT 80
  #define API_BASEADDRESS "/SkyMonitor.API/api/"
  
  #define __SKY_MONITOR_H__
  void print_packet(HardwareSerial* hwSerial, packet_t* packet);
  void send_packet(packet_t* packet);
#endif

