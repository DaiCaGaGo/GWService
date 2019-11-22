# GWService
 Services Conek
 - .Net Framework 4.6.1
 - Visual Studio 2019 Professional
 - Oracle 12.2.0.1.0 x64
 - RabbitMQ 3.7.16
 - Erlang 22
 <p>Nuget</p>
 <ul>
   <li>Oracle.ManagedDataAccess v19.3.1</li>
   <li>Dapper v1.60.6</li>
   <li>RabbitMQ v5.1.0</li>
   <li>Newtonsoft.Json v12.0.2</li>
   <li>log4net v2.0.8</li>
 </ul>
 
## Oracle Depenency
 - Check connection listener: SELECT * FROM USER_CHANGE_NOTIFICATION_REGS

## RabbitMQ
 - Firewall: Open port 15672
 - ConnectionString: "amqp://username:password@host:port/", Example = "amqp://luan:123456@115.84.178.66:5672/"
 - Enable RabbitMQ Manager: C:\Program Files\RabbitMQ Server\rabbitmq_server-3.7.16\sbin>rabbitmq-plugins enable rabbitmq_management
 - Username & password default: "guest"
 - Link manager: http://localhost:15672/
 - API: http://115.84.178.66:15672/api/queues/%2f/partner_south_queue

## Install Service
 - Config App.config "PARTNER.NAME"
 - Run: setup.cmd
 - Install Service: C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe %~dp0%SendSMS.exe

## Unistall Service
 - Run: unistall.cmd
 - Kill Service: taskkill -im SendSMS_SOUTH.exe /f
 - Delete Service: SC DELETE "Service Send SMS SOUTH" binPath= "D:\GateWay\SendSMS_INCOM\ServiceName.exe -c Service.config"
 - Unistall Service: C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe /u %~dp0%SendSMS.exe
 
## Start and Stop Service
 - Start: sc start "Service Send SMS SOUTH"
 - Stop:  sc stop "Service Send SMS SOUTH"
 
## Using SoapUI
 - Config path wsdl.exe: SoapUI > File > Preferences > Tool > .NET 2.0 wsdl.exe > Browse = "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools"
 - Generate Service: Project > Generate Code > .NET 2.0 Artifacts
	