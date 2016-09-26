# Exporter-Service-Now
Exporter Service-Now for pulling data in various formats from service now automatically

For Downloading Reports 
https://<instance-name>.service-now.com/sys_report_template.do?<format>&<query like this>jvar_report_id=3a0d2ce20fcaae802eadeee69205
<export format processor>
The following URL query produces an XML document similar to the sample shown:

https://<instance name>.service-now.com/incident_list.do?XML&sysparm_query=priority=1&sysparm_order_by=assigned_to


URL Query Parameters
ServiceNow provides the following URL query parameters:

URL Parameter	URL Syntax	Description
sysparm_query	sysparm_query=[column name][operator][value]	Displays a list of records that match the query. For example:
https://<instance name>.service-now.com/incident_list.do?XML&sysparm_query=priority=1

sysparm_order_by	sysparm_order_by=[column name]	Sorts a list of records by the column name provided. For example:
https://<instance name>.service-now.com/incident_list.do?sysparm_query=priority=1&sysparm_order_by=assigned_to

You can sort by only one column using sysparm_order_by. To sort by multiple columns, use sysparm_query=ORDERBY[column name]^ORDERBY[column name]. For example: sysparm_query=ORDERBYassigned_to^ORDERBYpriority.
