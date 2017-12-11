#ifndef __SKY_MONITOR_H__
  #if defined(ARDUINO) && ARDUINO >= 100
	  #include "Arduino.h"
  #else
	  #include "WProgram.h"
  #endif
  // Includes
  #include <GSM.h>
  #include <AltSoftSerial.h>
  #include <TinyGPS.h>

  #define PACKAGE_BUFFER_SIZE 12
  
  #ifndef __LOCATION_T__
  	typedef struct {
  	  float latitude;
  	  float longitude;
  	} location_t;
	  #define __LOCATION_T__
  #endif
  #ifndef __DEVICE_T__
  	typedef struct {
  		location_t location;
      int id;
  	} device_t;
	  #define __DEVICE_T__
  #endif
  #ifndef __PACKET_T__
  	typedef union {
  	  device_t device;
  	  unsigned char bytes[PACKAGE_BUFFER_SIZE];
  	} packet_t;
	  #define __PACKET_T__
  #endif
  #define DEVICE_ID 1
  #define SERIAL_BAUD_RATE 115200
  #define SS_BAUD_RATE 9600
  #define VERSION "SkyMonitor BETA 0.01"
  #define GPS_RX 9
  #define GPS_TX 8
  
  #define PINNUMBER ""
  #define GPRS_APN       "internet.movistar.com" // replace your GPRS APN
  #define GPRS_LOGIN     "movistar"    // replace with your GPRS login
  #define GPRS_PASSWORD  "movistar" // replace with your GPRS password

  #define API_SERVER "daemnin.dlinkddns.com"
  #define API_PORT 80

  #define __SKY_MONITOR_H__
  void print_packet(HardwareSerial* hwSerial, packet_t* packet);
  void send_packet(HardwareSerial* hwSerial, GSMClient* client, packet_t* packet);
#endif
