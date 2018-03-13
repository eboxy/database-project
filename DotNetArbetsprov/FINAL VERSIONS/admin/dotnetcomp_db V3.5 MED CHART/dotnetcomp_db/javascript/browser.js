<!--
browser_version= parseInt(navigator.appVersion);
browser_type = navigator.appName;
agentheadz_ff=navigator.userAgent.indexOf("Firefox")
agentheadz_cr=navigator.userAgent.indexOf("Chrome")


if (browser_type == "Microsoft Internet Explorer" && (browser_version >= 4))
{
document.write("<link REL='stylesheet' HREF='styles/style_IE.css' TYPE='text/css'>");
}

else if (browser_type == "Netscape" && (browser_version >= 4)&& agentheadz_ff!=-1)
{
document.write("<link REL='stylesheet' HREF='styles/style_FF.css' TYPE='text/css'>");
}

else if (browser_type == "Netscape" && agentheadz_cr!=-1)
{
document.write("<link REL='stylesheet' HREF='styles/style_CR.css' TYPE='text/css'>");
}

// -->



