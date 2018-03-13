<!--

function datum()
{
//Inhämtande av tidsuppgifter:
nydatum = new Date();
var year = nydatum.getYear();
var month = nydatum.getMonth()+1;
var day = nydatum.getDate();
var hour=nydatum.getHours();
var minute=nydatum.getMinutes();
var second=nydatum.getSeconds();

    //Tidsjusteringar:
    year=(year< 1000 ? 1900 : "" )+year;
    month=(month< 10 ? "0" : "" )+month;
    day=(day< 10 ? "0" : "" )+day;
    hour=(hour < 10 ? "0" : "" )+hour;
    minute=( minute < 10 ? "0" : "" )+minute;
    second=(second< 10 ? "0" : "" )+second;

//Skapande av tids-sträng:
var timestring=year+"-"+month+"-"+day+" "+hour+":"+minute+":"+second;

//Utskrift:
document.getElementById("clock").firstChild.nodeValue = timestring;

}

// -->