//dentv check ngay gio

/*function DeltaNumber(field1, field2)
{
var numbe = 0;
var value1 =field1.value;
	
var  = field2.value;
	
if(value1 =="" || value2=="") return "";
	
return number = value1-value2;
	
}*/

function DeltaDate(field1, field2) {

    var value1 = field1.value;

    var value2 = field2.value;

    if (value1 == "" || value2 == "") return "";
    //var Hour1 = value1.substr(11,5);
    //var Hour2 = value2.substr(11,5);
    var date1 = value1.substr(0, 10);
    var date2 = value2.substr(0, 10);

    var deltaDate = DeltaDate1Date(date1, date2) - 1;
    /*var deltaHour = 0;
    if(deltaDate==0)
    {
    deltaHour = DeltaHourToHour(Hour1,Hour2);
    }else{
    deltaHour = DeltaHourToHour(Hour1,'23:59')+DeltaHourToHour('00:00',Hour2);
    }
    //alert(deltaDate);*/
    if (deltaDate >= 1) {
        deltaDate = deltaDate - 1;
    }
    return deltaDate; //deltaDate*24*60 + 1 + deltaHour;
}

function DeltaDateHourCtl(field1, field2) {

    var value1 = checkDateHours(field1.value);

    var value2 = checkDateHours(field2.value);

    if (value1 == "" || value2 == "") return "";
    var Hour1 = value1.substr(11, 5);
    var Hour2 = value2.substr(11, 5);
    var date1 = value1.substr(0, 10);
    var date2 = value2.substr(0, 10);

    var deltaDate = DeltaDate1Date(date1, date2) - 1;
    var deltaHour = 0;
    if (deltaDate == 0) {
        deltaHour = DeltaHourToHour(Hour1, Hour2);
    } else {
        deltaHour = DeltaHourToHour(Hour1, '23:59') + DeltaHourToHour('00:00', Hour2);
    }
    //alert(deltaDate);
    if (deltaDate >= 1) {
        deltaDate = deltaDate - 1;
    }
    return deltaDate * 24 * 60 + deltaHour;
}
function checkDateHourCtl(field) {
    if (trimString(field.value) == "") {
        field.value = "";
        return true;
    }
    var result = checkDateHours(field.value);
    if (result == "") {
        alert('Nhap ngay gio khong dung dinh dang (dd/mm/yyyy hh:mi)!')
        field.focus();
        return false;

    }
    field.value = result;
    return true;
}
function checkDateHours(value) {
    var checkstr = "0123456789";
    //var DateField = field;
    var Datevalue = "";
    var DateTemp = "";
    var seperator = "/";
    var DateValue = "";
    var HourValue = "";
    DateValue = value;

    for (i = 0; i < DateValue.length; i++) {
        if (checkstr.indexOf(DateValue.substr(i, 1)) >= 0) {
            DateTemp = DateTemp + DateValue.substr(i, 1);
        }
    }
    if (DateTemp.length < 10) {
        return "";
    } else {
        HourValue = DateTemp.substr(DateTemp.length - 4, 4);
        DateValue = DateTemp.substr(0, DateTemp.length - 4);
    }
    DateValue = CheckDate(DateValue);
    HourValue = formatHours(HourValue);
    if (DateValue == "" || HourValue == "") {
        return "";
    } else {
        return DateValue + " " + HourValue;
    }
}
function formatHours(value) {
    var nSep1, sHour, sMinute, nHour, nMinute;
    var checkstr = "0123456789";
    var DataTemp = "";
    var DataValue = "";
    var value, i;
    DataValue = value;
    if (DataValue.length == 0) {
        return "";
    }
    //Bo nhung ky tu khong phai ky tu so
    for (i = 0; i < DataValue.length; i++) {
        if (checkstr.indexOf(DataValue.substr(i, 1)) >= 0) {
            DataTemp = DataTemp + DataValue.substr(i, 1);
        }
    }
    if (DataTemp.length != 4) {
        return "";

    }
    sHour = DataTemp.substring(0, 2);
    sMinute = DataTemp.substring(2, 4);
    if (isNaN(sHour) || isNaN(sMinute)) {
        return "";
    }

    nHour = parseInt(sHour, 10); nMinute = parseInt(sMinute, 10);
    if (nHour < 0 || nMinute < 0) {
        return "";
    }
    if (nHour >= 24 || nMinute >= 60) {
        return "";
    }
    value = sHour + ":" + sMinute;
    return value;
}

function CheckDate(value) {
    var checkstr = "0123456789";
    //var DateField = field;
    var Datevalue = "";
    var DateTemp = "";
    var seperator = "/";
    var day;
    var month;
    var year;
    var leap = 0;
    var err = 0;
    var i;
    err = 0;
    DateValue = value;
    /* Delete all chars except 0..9 */
    for (i = 0; i < DateValue.length; i++) {
        if (checkstr.indexOf(DateValue.substr(i, 1)) >= 0) {
            DateTemp = DateTemp + DateValue.substr(i, 1);
        }
    }
    DateValue = DateTemp;
    /* Always change date to 8 digits - string*/
    /* if year is entered as 2-digit / always assume 20xx */
    if (DateValue.length == 6) {
        DateValue = DateValue.substr(0, 4) + '20' + DateValue.substr(4, 2);
    }

    if (DateValue.length != 8) {
        err = 19;
    }
    /* year is wrong if year = 0000 */
    year = DateValue.substr(4, 4);
    if (year == 0) {
        err = 20;
    }
    /* Validation of month*/
    month = DateValue.substr(2, 2);
    if ((month < 1) || (month > 12)) {
        err = 21;
    }
    /* Validation of day*/
    day = DateValue.substr(0, 2);

    if (year <= 1900) {
        err = 18;
    }
    if (day < 1) {
        err = 22;
    }
    /* Validation leap-year / february / day */
    if ((year % 4 == 0) || (year % 100 == 0) || (year % 400 == 0)) {
        leap = 1;
    }
    if ((month == 2) && (leap == 1) && (day > 29)) {
        err = 23;
    }
    if ((month == 2) && (leap != 1) && (day > 28)) {
        err = 24;
    }
    /* Validation of other months */
    if ((day > 31) && ((month == "01") || (month == "03") || (month == "05") || (month == "07") || (month == "08") || (month == "10") || (month == "12"))) {
        err = 25;
    }
    if ((day > 30) && ((month == "04") || (month == "06") || (month == "09") || (month == "11"))) {
        err = 26;
    }
    /* if 00 ist entered, no error, deleting the entry */
    if ((day == 0) && (month == 0) && (year == 00)) {
        err = 0; day = ""; month = ""; year = ""; seperator = "";
    }
    /* if no error, write the completed date to Input-Field (e.g. 13.12.2001) */
    if (err == 0) {
        return day + seperator + month + seperator + year;
    }
    else if (err = 18)/* Error-message if err != 0 */
    {
        return "";
    }
    else {
        return "";
    }
}

function DeltaHourToHour(DataTemp1, DataTemp2) {
    var sHour1, sMinute1, sHour2, sMinute2;
    var Time1, Time2;

    sHour1 = DataTemp1.substring(0, 2);
    sMinute1 = DataTemp1.substring(3, 5);
    sHour2 = DataTemp2.substring(0, 2);
    sMinute2 = DataTemp2.substring(3, 5);
    Time1 = eval(sHour1) * 60 + eval(sMinute1);
    Time2 = eval(sHour2) * 60 + eval(sMinute2);
    return Time2 - Time1;

}
function DeltaDate1Date(value1, value2) {

    if (value1 == "" || value2 == "")
        return;
    var checkstr = "0123456789";
    var seperator = "/";
    var i;
    var valueTemp1 = "";
    var valueTemp2 = "";
    /* Delete all chars except 0..9 */
    for (i = 0; i < value1.length; i++) {
        if (checkstr.indexOf(value1.substr(i, 1)) >= 0) {
            valueTemp1 = valueTemp1 + value1.substr(i, 1);
        }
    }
    for (i = 0; i < value2.length; i++) {
        if (checkstr.indexOf(value2.substr(i, 1)) >= 0) {
            valueTemp2 = valueTemp2 + value2.substr(i, 1);
        }
    }
    value1 = valueTemp1;
    value2 = valueTemp2;
    year1 = value1.substr(4, 4);
    month1 = value1.substr(2, 2);
    day1 = value1.substr(0, 2);
    year2 = value2.substr(4, 4);
    month2 = value2.substr(2, 2);
    day2 = value2.substr(0, 2);
    var delta = Date.UTC(parseInt(year2, 10), parseInt(month2, 10) - 1, parseInt(day2, 10)) - Date.UTC(parseInt(year1, 10), parseInt(month1, 10) - 1, parseInt(day1, 10));
    return ((delta / 86400000) + 1)
}

//Hide or show by object obj
function display(obj, id) {
    if (obj.checked == false) {
        document.getElementById(id).style.display = 'none';
    }
    else {
        document.getElementById(id).style.display = 'block';
    }
}

/*
width_size=chieu rong man hinh
heith_size-chieu dai man hinh
scroll_bar: yes, no
*/
//end cac ham dung cho form hach toan

function roundNumber(rnum, rlength) { // Arguments: number to round, number of decimal places
    var newnumber = Math.round(rnum * Math.pow(10, rlength)) / Math.pow(10, rlength);
    //document.roundform.numberfield.value = newnumber;
    return newnumber;
}

function replaceAmpersand(str) {
    return (str.replace(/&/g, "amp;"));
}

function checkDate(tungay, denngay)//tungay<denngay?true:false
{
    var strTuNgay = document.getElementById(tungay).value;
    var strDenNgay = document.getElementById(denngay).value;
    if (trimString(strTuNgay) == "" || trimString(strDenNgay) == "") {
        //alert("123");
        return true;
    } else {
        var dTuNgay = getDateFromFormat(strTuNgay, "dd/MM/yyyy");
        var dDenNgay = getDateFromFormat(strDenNgay, "dd/MM/yyyy");
        if (difference(dTuNgay, dDenNgay) < 0) {
            //alert("Tu ngay khong duoc lon hon den ngay");
            return false;
        } else {
            return true;
        }
    }
}
//so sanh 2 ngay ----HUYNQ---Truyen vao 2 tham so voi kieu dinh dang ngay:dd/MM/yyyy 
function checkDateString(strDate1, strDate2) {
    if (trimString(strDate1) == "" || trimString(strDate2) == "") {
        return true;
    } else {
        //var	date1 =   getDateFromFormat(strDate1,"dd/MM/yyyy");
        //var date2 =   getDateFromFormat(strDate2,"dd/MM/yyyy");
        if (difference(strDate1, strDate2) <= 0) {
            //strDate1 > strDate2
            return false;
        } else {
            return true;
        }
    }
}

function getToDate(dateString) {
    var tmp = dateString.split("/");
    var date = new Date();
    date.setFullYear(parseInt(tmp[2]), parseInt(tmp[1]), parseInt(tmp[0]));
    /*alert(tmp[2]);
    alert(parseInt(tmp[1]-1));
    alert(parseInt(tmp[0]));*/
    return date;
}
//tra ve hieu cua 2 ngay 
function difference(dateStart, dateEnd) {
    var one_day = 1000 * 60 * 60 * 24;
    var date1 = getDateFromFormat(dateStart, "dd/MM/yyyy");
    var date2 = getDateFromFormat(dateEnd, "dd/MM/yyyy");
    var diff = date2.getTime() - date1.getTime();
    //var diff = getToDate(dateEnd).getTime() - getToDate(dateStart).getTime();		
    return Math.floor(diff / one_day);
    //return Math.ceil((dateEnd.getTime() - dateStart.getTime())/one_day);
}
function popUpMaHS(fileName, width_size, heigth_size, scroll_bar) {

    var str = 'location=no,menubar=no,width=' + width_size + ', height=' + heigth_size + ',scrollbars=' + scroll_bar + ',status=yes';
    if (window.screen) {
        var widthScreen = screen.availWidth - 10;
        var heightScreen = screen.availHeight - 30;
        var x = (widthScreen - width_size) / 2;
        var y = (heightScreen - heigth_size) / 2;
        str += ',left=' + x + ',screenX=' + x;
        str += ',top=' + y + ',screenY=' + y;
    }
    var win = window.open(fileName, 'sub_window', str);
    win.focus();
    return win;

}

function showChiTietHS(mshoso) {
    popUpMaHS("hoso?action=6&mshoso=" + mshoso, 700, 500, 'yes');
}
function selectAll(source_obj, target_name) {
    var flag = source_obj.checked;
    var target_obj = document.getElementsByName(target_name);
    for (var i = 0; i < target_obj.length; i++) {
        if (target_obj[i].disabled == false)
            target_obj[i].checked = flag;
    }
}

// PhuongDK: them ham SelectAllNew cho truong hop phat sinh cac checkbox
function selectAllNew(source_obj, target_name, num) {
    var flag = source_obj.checked;

    for (var j = 1; j <= num; j++) {
        var target_obj = document.getElementsByName(target_name + j);
        target_obj[0].checked = flag
    }
}

//btn_id: ten id cua button
function search(btn_id) {

    var btn = document.getElementById(btn_id);
    var key;
    if (event.keyCode) {
        key = event.keyCode;
    } else {
        key = event.which;
    }
    if (key == 13) {

        btn.click();
    }
}
//lay ra ngay hien tai
function getCurrentDate() {
    var curDate = new Date();
    var intMonth;
    var strMonth;

    intMonth = curDate.getMonth() + 1;

    if (intMonth < 10) {
        strMonth = curDate.getMonth() + 1;
        strMonth = "0" + strMonth;
    } else {
        strMonth = curDate.getMonth() + 1;
    }
    return curDate.getDate() + "/" + strMonth + "/" + curDate.getYear();
}

//PhuongDK: 21-03-2006, lay ra ngay dau thang
function getFirstDate() {
    var curDate = new Date();

    return "01/" + (curDate.getMonth() + 1) + "/" + curDate.getYear();
}

function setOffset(objSource, objTarget) {
    objSource.style.left = caculateOffsetLeft(objTarget);
    var top = caculateOffsetTop(objTarget) + objTarget.offsetHeight;
    objSource.style.top = top;
}

function caculateOffsetLeft(obj) {
    var leftOffset = obj.offsetLeft;
    while (obj = obj.offsetParent) {
        leftOffset += obj.offsetLeft;
    }
    return leftOffset
}
function caculateOffsetTop(obj) {
    var topOffset = obj.offsetTop;
    while (obj = obj.offsetParent) {
        topOffset += obj.offsetTop;
    }
    return topOffset
}
function createXMLHttpRequest() {
    if (window.ActiveXObject) {
        xmlHttpRequest = new ActiveXObject("Microsoft.XMLHttp");
    } else {
        xmlHttpRequest = new XMLHttpRequest();
    }
}
//data: id cua select box	
function clear(data) {
    var selObj = document.getElementById(data);
    for (var i = selObj.options.length; i >= 0; i--) {
        selObj.remove(i);
    }
}
function sendRequest(url, handleResponse) {
    var selObj = document.getElementById("data");
    if (event.keyCode == 40 && selObj.length >= 0) {
        selObj.focus();
    } else {
        createXMLHttpRequest();
        //var url ="seachnganhangvms?tennganhang="+document.getElementById("tennganhangvms").value;		
        xmlHttpRequest.open("GET", url, true);
        xmlHttpRequest.onreadystatechange = handleResponse;
        xmlHttpRequest.send(null);
    }
}
function inputNumber(obj) {
    obj.value = obj.value.replace(/\D/, '');
}

// PhuongDK: 14-03-2006, 
// sua lai ham addCommas(obj) --> loai bo cac ky tu chu, chi lay ky tu so: 0..9
function clrTextBox(obj) {
    if (obj.value == '0') {
        obj.value = '';
    }
}
function AddValueForTextbox(obj) {
    if (obj.value == '') {
        obj.value = '0';
    }
}


function addCommas(event, obj) {
    event = event || window.event;
    if (event.keyCode == 16 || event.keyCode == 9) {
        return;
        obj.select();
    }

    var val;
    val = obj.value;
    //tach phan thap phan
    var d = val.split(".");

    val = d[0].replace(/,/g, "");
    var arr = val.split("");
    var stmp = "";
    var flag = 0;
    var arr_size = arr.length;
    var s = "";
    var valid = 0;
    var arrValid = new Array(10);

    arrValid[0] = '0'; arrValid[1] = '1'; arrValid[2] = '2'; arrValid[3] = '3'; arrValid[4] = '4';
    arrValid[5] = '5'; arrValid[6] = '6'; arrValid[7] = '7'; arrValid[8] = '8'; arrValid[9] = '9';
    /*
    if(event.keyCode==8){
    return;
    }*/
    if (event.keyCode == 37) {
        return;
    }

    if (event.keyCode == 39) {
        return;
    }


    for (i = arr_size - 1; i >= 0; i--) {
        valid = 0;
        for (j = 0; j <= 10; j++) {
            if (arr[i] == arrValid[j]) {
                valid = 1;
                break;
            }
        }

        if (valid == 1) {
            stmp = arr[i] + stmp;
            flag++;
            //alert(flag);
            if (flag % 3 == 0 && i != 0) {
                stmp = "," + stmp;
            }
        }
    }
    if (d.length == 2)
        obj.value = stmp + "." + d[1];
    else
        obj.value = stmp;
}

function addCommasString(str) {
    //str = str.replace(/,/g,"");
    str = str + '';
    dauam = '';
    if (parseFloat(str) < 0) {
        dauam = '-';
        str = (parseFloat(str) * (-1)) + '';
    }
    var arr = str.split("");
    var stmp = "";
    var flag = 0;
    var arr_size = arr.length;
    var s = "";
    var valid = 0;
    var arrValid = new Array(10);

    arrValid[0] = '0'; arrValid[1] = '1'; arrValid[2] = '2'; arrValid[3] = '3'; arrValid[4] = '4';
    arrValid[5] = '5'; arrValid[6] = '6'; arrValid[7] = '7'; arrValid[8] = '8'; arrValid[9] = '9'; arrValid[10] = '.';


    for (i = arr_size - 1; i >= 0; i--) {
        valid = 0;
        for (j = 0; j <= 10; j++) {
            if (arr[i] == arrValid[j]) {
                valid = 1;
                break;
            }
        }
        if (j == 10) { flag = -1; }
        if (valid == 1) {
            stmp = arr[i] + stmp;
            flag++;
            //alert(flag);
            if (flag % 3 == 0 && i != 0 && flag > 0) {
                stmp = "," + stmp;
            }
        }
    }

    return dauam + stmp;
}

function addCommasHaveNegNum(obj) {
    var val;
    val = obj.value;
    val = val.replace(/,/g, "");
    var isNegativeInt = 0;
    if (val < 0) {
        val = val.substring(1, val.length);
        //val = val.replace(/,/g,"");	
        //alert(val);
        isNegativeInt = 1;
    }
    var arr = val.split("");

    var stmp = "";
    var flag = 0;
    var arr_size = arr.length;
    var s = "";
    var valid = 0;
    var arrValid = new Array(11);

    arrValid[0] = '0'; arrValid[1] = '1'; arrValid[2] = '2'; arrValid[3] = '3'; arrValid[4] = '4';
    arrValid[5] = '5'; arrValid[6] = '6'; arrValid[7] = '7'; arrValid[8] = '8'; arrValid[9] = '9';
    arrValid[10] = '-';


    if (event.keyCode == 8) {
        return;
    }
    if (event.keyCode == 37) {
        return;
    }

    if (event.keyCode == 39) {
        return;
    }


    for (i = arr_size - 1; i >= 0; i--) {
        valid = 0;
        for (j = 0; j <= 10; j++) {
            if (arr[i] == arrValid[j]) {
                valid = 1;
                break;
            }
        }

        if (valid == 1) {
            stmp = arr[i] + stmp;
            flag++;
            //alert(flag);
            if (flag % 3 == 0 && i != 0) {
                stmp = "," + stmp;
            }
        }
    }

    if (isNegativeInt == 1) {
        obj.value = "-" + stmp;
    }
    else {
        obj.value = stmp;
    }
}


//them dau / vao ngay
var oldDate = "";
function addDashes(obj) {
    var currValue = obj.value;
    var currentDate = sServerToday;

    //alert("date");
    if (IsDateString(currValue) == false) {
        obj.value = "";
        return;
    }

    if (event.keyCode == 8 || event.keyCode == 37 || event.keyCode == 39 || event.keyCode == 36 || event.keyCode == 35 || event.keyCode == 46) {
        return;
    }
    else
        if (event.keyCode == 84) {
            obj.value = currentDate;
            return;
        }

    // PhuongDK
    if (oldDate == "") {
        oldDate = getCurrentDate();
    }

    try {
        currValue = currValue.split("/").join("");
        if (currValue.length > 8) {
            var arr = obj.value.split("/");
            if (arr[0].length > 2) {
                var arrOldDate = oldDate.split("/");
                currValue = arrOldDate[0] + currValue.substr(3, currValue.length);
            }
            if (arr[1].length > 2) {
                var arrOldDate = oldDate.split("/");
                currValue = arr[0] + arrOldDate[1] + currValue.substr(5, currValue.length);
            }
            if (arr[2].length > 4) {
                var arrOldDate = oldDate.split("/");
                currValue = arr[0] + arr[1] + arrOldDate[2];
            }
        }

        if (currValue.length == 2) {
            obj.value = currValue + "/";
        }
        if (currValue.length == 4) {
            obj.value = currValue.replace(/(\d{2})(\d{2})/, "$1/$2/");
        }
        if (currValue.length == 6) {
            obj.value = currValue.substr(0, 4) + "20" + currValue.substr(4, 5);
            obj.value = obj.value.replace(/(\d{2})(\d{2})(\d{4})/, "$1/$2/$3");
        }
        if (currValue.length == 8) {
            obj.value = currValue.replace(/(\d{2})(\d{2})(\d{4})/, "$1/$2/$3");
        }
    } catch (e) {
        obj.value = "";
    }
}

// PhuongDK: Kiem tra chuoi date
function IsDateString(sText) {
    var ValidChars = "0123456789/";
    var IsNumber = true;
    var Char;


    for (i = 0; i < sText.length && IsNumber == true; i++) {
        Char = sText.charAt(i);
        if (ValidChars.indexOf(Char) == -1) {
            IsNumber = false;
        }
    }
    return IsNumber;

}


// PhuongDK: Kiem tra kieu so
function IsNumeric(sText) {
    var ValidChars = "0123456789";
    var IsNumber = true;
    var Char;


    for (i = 0; i < sText.length && IsNumber == true; i++) {
        Char = sText.charAt(i);
        if (ValidChars.indexOf(Char) == -1) {
            IsNumber = false;
        }
    }
    return IsNumber;

}

//load focus vao element dau tien cua form
function getFocus() {
    document.forms[0].elements[0].focus();
}
function hiddenElement(idObj) {
    var ele = document.getElementById(idObj);
    ele.style.display = "none";
}

function displayElement(idObj) {
    var ele = document.getElementById(idObj);
    //ele.style.display="block";
    ele.style.display = "inline";

}

function popUpDialog(fileName, width_size, heigth_size, data) {
    var str = 'dialogWidth:' + width_size + 'px,dialogHeight:' + heigth_size + 'px,status:no';
    var _result = window.showModalDialog(fileName, data, str);
    return _result;

}

// PhuongDK: 22-03-2006, them ham cat khoang trang cho chuoi
function trimString(inputString) {

    if (typeof inputString != "string") { return inputString; }
    var retValue = inputString;
    var ch = retValue.substring(0, 1);
    while (ch == " ") { // Cat khoang trang o dau chuoi
        retValue = retValue.substring(1, retValue.length);
        ch = retValue.substring(0, 1);
    }
    ch = retValue.substring(retValue.length - 1, retValue.length);
    while (ch == " ") { // Cat khoang trang o cuoi chuoi
        retValue = retValue.substring(0, retValue.length - 1);
        ch = retValue.substring(retValue.length - 1, retValue.length);
    }
    while (retValue.indexOf("  ") != -1) {
        retValue = retValue.substring(0, retValue.indexOf("  ")) + retValue.substring(retValue.indexOf("  ") + 1, retValue.length); // Again, there are two spaces in each of the strings
    }
    return retValue;
}

// Ham kiem tra kieu ngay thang
var dtCh = "/";
var minYear = 1900;
var maxYear = 2100;

function isInteger(s) {
    var i;
    for (i = 0; i < s.length; i++) {

        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }

    return true;
}

function stripCharsInBag(s, bag) {
    var i;
    var returnString = "";

    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}

function daysInFebruary(year) {
    return (((year % 4 == 0) && ((!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28);
}
function DaysArray(n) {
    for (var i = 1; i <= n; i++) {
        this[i] = 31
        if (i == 4 || i == 6 || i == 9 || i == 11) { this[i] = 30 }
        if (i == 2) { this[i] = 29 }
    }
    return this
}

function isDate_(dtStr) {
    var daysInMonth = DaysArray(12)
    var pos1 = dtStr.indexOf(dtCh)
    var pos2 = dtStr.indexOf(dtCh, pos1 + 1)
    var strDay = dtStr.substring(0, pos1)
    var strMonth = dtStr.substring(pos1 + 1, pos2)
    var strYear = dtStr.substring(pos2 + 1)
    strYr = strYear
    if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1)
    if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1)
    for (var i = 1; i <= 3; i++) {
        if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1)
    }
    month = parseInt(strMonth)
    day = parseInt(strDay)
    year = parseInt(strYr)
    if (pos1 == -1 || pos2 == -1) {
        //alert("The date format should be : dd/mm/yyyy")
        return false
    }
    if (strMonth.length < 1 || month < 1 || month > 12) {
        //alert("Please enter a valid month")
        return false
    }
    if (strDay.length < 1 || day < 1 || day > 31 || (month == 2 && day > daysInFebruary(year)) || day > daysInMonth[month]) {
        //alert("Please enter a valid day")
        return false
    }
    if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
        //alert("Please enter a valid 4 digit year between "+minYear+" and "+maxYear)
        return false
    }
    if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isInteger(stripCharsInBag(dtStr, dtCh)) == false) {
        //alert("Please enter a valid date")
        return false
    }
    return true
}

function getShortString(strText, len) {
    if (strText.length > len) {
        strText = strText.substring(0, len) + "...";
    }
    return strText;
}
function setHiddenErrorMess() {
    document.getElementById("error_registration").style.display = '';
    //v.exec();
    /*	var o_form = document.forms[0];
    if (!o_form)	
    return this.f_alert(this.f_error(2));
		
    b_dom = document.body && document.body.innerHTML;
    if (b_dom)
    for (var n_key in this.a_fields) 
    if (this.a_fields[n_key]['t']) {
    var s_labeltag = this.a_fields[n_key]['t'], e_labeltag = get_element(s_labeltag);
    if (!e_labeltag)
    return this.f_alert(this.f_error(5, this.a_fields[n_key]));
    this.a_fields[n_key].o_tag = e_labeltag;
				
    // normal state parameters assigned here
    e_labeltag.className = 'tfvNormal';
    }*/
}
function getShortString(strText, len) {
    if (strText.length > len) {
        strText = strText.substring(0, len) + "...";
    }
    return strText;
}
//Doc text hien thi tu ComboBox
function getTextCB(nameOfComboBox) {
    var arr = document.getElementById(nameOfComboBox);
    var lengthArr = arr.length;
    for (var i = 0; i < lengthArr; i++) {
        if (arr[i].selected) {
            return arr[i].text;
        }
    }
}

//Doc text hien thi tu ComboBox
function getTextCBList(nameOfComboBox, idx) {
    var arr = document.getElementById(nameOfComboBox)[idx];
    var lengthArr = arr.length;
    for (var i = 0; i < lengthArr; i++) {
        if (arr[i].selected) {
            return arr[i].text;
        }
    }
}


//Chan nut F5 lai
if (document.all) {
    document.onkeydown = function () {
        var key_f5 = 116; // 116 = F5
        if (key_f5 == event.keyCode) {
            event.keyCode = 0;
            return false;
        }
    }
}
/**
* @param strChk      String to be cleaned
* @param strFind     String to replace
* @param strReplace  String to insert
* @return            String without unwanted characters/strings
*/
function replaceAll(strChk, strFind, strReplace) {
    var strOut = strChk;
    while (strOut.indexOf(strFind) > -1) {
        strOut = strOut.replace(strFind, strReplace);
    }
    return strOut;
}


//cac ham xu ly ngay
// ===================================================================
// Author: Matt Kruse <matt@mattkruse.com>
// WWW: http://www.mattkruse.com/
//
// NOTICE: You may use this code for any purpose, commercial or
// private, without any further permission from the author. You may
// remove this notice from your final code if you wish, however it is
// appreciated by the author if at least my web site address is kept.
//
// You may *NOT* re-distribute this code in any way except through its
// use. That means, you can include it in your product, or your web
// site, or any other form where the code is actually being used. You
// may not put the plain javascript up on your site for download or
// include it in your javascript libraries for download. 
// If you wish to share this code with others, please just point them
// to the URL instead.
// Please DO NOT link directly to my .js files from your site. Copy
// the files to your server and use them there. Thank you.
// ===================================================================

// HISTORY
// ------------------------------------------------------------------
// May 17, 2003: Fixed bug in parseDate() for dates <1970
// March 11, 2003: Added parseDate() function
// March 11, 2003: Added "NNN" formatting option. Doesn't match up
//                 perfectly with SimpleDateFormat formats, but 
//                 backwards-compatability was required.

// ------------------------------------------------------------------
// These functions use the same 'format' strings as the 
// java.text.SimpleDateFormat class, with minor exceptions.
// The format string consists of the following abbreviations:
// 
// Field        | Full Form          | Short Form
// -------------+--------------------+-----------------------
// Year         | yyyy (4 digits)    | yy (2 digits), y (2 or 4 digits)
// Month        | MMM (name or abbr.)| MM (2 digits), M (1 or 2 digits)
//              | NNN (abbr.)        |
// Day of Month | dd (2 digits)      | d (1 or 2 digits)
// Day of Week  | EE (name)          | E (abbr)
// Hour (1-12)  | hh (2 digits)      | h (1 or 2 digits)
// Hour (0-23)  | HH (2 digits)      | H (1 or 2 digits)
// Hour (0-11)  | KK (2 digits)      | K (1 or 2 digits)
// Hour (1-24)  | kk (2 digits)      | k (1 or 2 digits)
// Minute       | mm (2 digits)      | m (1 or 2 digits)
// Second       | ss (2 digits)      | s (1 or 2 digits)
// AM/PM        | a                  |
//
// NOTE THE DIFFERENCE BETWEEN MM and mm! Month=MM, not mm!
// Examples:
//  "MMM d, y" matches: January 01, 2000
//                      Dec 1, 1900
//                      Nov 20, 00
//  "M/d/yy"   matches: 01/20/00
//                      9/2/00
//  "MMM dd, yyyy hh:mm:ssa" matches: "January 01, 2000 12:30:45AM"
// ------------------------------------------------------------------

var MONTH_NAMES = new Array('January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December', 'Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec');
var DAY_NAMES = new Array('Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat');
function LZ(x) { return (x < 0 || x > 9 ? "" : "0") + x }

// ------------------------------------------------------------------
// isDate ( date_string, format_string )
// Returns true if date string matches format of format string and
// is a valid date. Else returns false.
// It is recommended that you trim whitespace around the value before
// passing it to this function, as whitespace is NOT ignored!
// ------------------------------------------------------------------
function isDate(val, format) {
    var date = getDateFromFormat(val, format);
    if (date == 0) { return false; }
    return true;
}

// -------------------------------------------------------------------
// compareDates(date1,date1format,date2,date2format)
//   Compare two date strings to see which is greater.
//   Returns:
//   1 if date1 is greater than date2
//   0 if date2 is greater than date1 of if they are the same
//  -1 if either of the dates is in an invalid format
// -------------------------------------------------------------------
function compareDates(date1, dateformat1, date2, dateformat2) {
    var d1 = getDateFromFormat(date1, dateformat1);
    var d2 = getDateFromFormat(date2, dateformat2);
    if (d1 == 0 || d2 == 0) {
        return -1;
    }
    else if (d1 > d2) {
        return 1;
    }
    return 0;
}

// ------------------------------------------------------------------
// formatDate (date_object, format)
// Returns a date in the output format specified.
// The format string uses the same abbreviations as in getDateFromFormat()
// ------------------------------------------------------------------
function formatDate(date, format) {
    format = format + "";
    var result = "";
    var i_format = 0;
    var c = "";
    var token = "";
    var y = date.getYear() + "";
    var M = date.getMonth() + 1;
    var d = date.getDate();
    var E = date.getDay();
    var H = date.getHours();
    var m = date.getMinutes();
    var s = date.getSeconds();
    var yyyy, yy, MMM, MM, dd, hh, h, mm, ss, ampm, HH, H, KK, K, kk, k;
    // Convert real date parts into formatted versions
    var value = new Object();
    if (y.length < 4) { y = "" + (y - 0 + 1900); }
    value["y"] = "" + y;
    value["yyyy"] = y;
    value["yy"] = y.substring(2, 4);
    value["M"] = M;
    value["MM"] = LZ(M);
    value["MMM"] = MONTH_NAMES[M - 1];
    value["NNN"] = MONTH_NAMES[M + 11];
    value["d"] = d;
    value["dd"] = LZ(d);
    value["E"] = DAY_NAMES[E + 7];
    value["EE"] = DAY_NAMES[E];
    value["H"] = H;
    value["HH"] = LZ(H);
    if (H == 0) { value["h"] = 12; }
    else if (H > 12) { value["h"] = H - 12; }
    else { value["h"] = H; }
    value["hh"] = LZ(value["h"]);
    if (H > 11) { value["K"] = H - 12; } else { value["K"] = H; }
    value["k"] = H + 1;
    value["KK"] = LZ(value["K"]);
    value["kk"] = LZ(value["k"]);
    if (H > 11) { value["a"] = "PM"; }
    else { value["a"] = "AM"; }
    value["m"] = m;
    value["mm"] = LZ(m);
    value["s"] = s;
    value["ss"] = LZ(s);
    while (i_format < format.length) {
        c = format.charAt(i_format);
        token = "";
        while ((format.charAt(i_format) == c) && (i_format < format.length)) {
            token += format.charAt(i_format++);
        }
        if (value[token] != null) { result = result + value[token]; }
        else { result = result + token; }
    }
    return result;
}

// ------------------------------------------------------------------
// Utility functions for parsing in getDateFromFormat()
// ------------------------------------------------------------------
function _isInteger(val) {
    var digits = "1234567890";
    for (var i = 0; i < val.length; i++) {
        if (digits.indexOf(val.charAt(i)) == -1) { return false; }
    }
    return true;
}
function _getInt(str, i, minlength, maxlength) {
    for (var x = maxlength; x >= minlength; x--) {
        var token = str.substring(i, i + x);
        if (token.length < minlength) { return null; }
        if (_isInteger(token)) { return token; }
    }
    return null;
}

// ------------------------------------------------------------------
// getDateFromFormat( date_string , format_string )
//
// This function takes a date string and a format string. It matches
// If the date string matches the format string, it returns the 
// getTime() of the date. If it does not match, it returns 0.
// ------------------------------------------------------------------
function getDateFromFormat(val, format) {
    val = val + "";
    format = format + "";
    var i_val = 0;
    var i_format = 0;
    var c = "";
    var token = "";
    var token2 = "";
    var x, y;
    var now = new Date();
    var year = now.getYear();
    var month = now.getMonth() + 1;
    var date = 1;
    var hh = now.getHours();
    var mm = now.getMinutes();
    var ss = now.getSeconds();
    var ampm = "";

    while (i_format < format.length) {
        // Get next token from format string
        c = format.charAt(i_format);
        token = "";
        while ((format.charAt(i_format) == c) && (i_format < format.length)) {
            token += format.charAt(i_format++);
        }
        // Extract contents of value based on format token
        if (token == "yyyy" || token == "yy" || token == "y") {
            if (token == "yyyy") { x = 4; y = 4; }
            if (token == "yy") { x = 2; y = 2; }
            if (token == "y") { x = 2; y = 4; }
            year = _getInt(val, i_val, x, y);
            if (year == null) { return 0; }
            i_val += year.length;
            if (year.length == 2) {
                if (year > 70) { year = 1900 + (year - 0); }
                else { year = 2000 + (year - 0); }
            }
        }
        else if (token == "MMM" || token == "NNN") {
            month = 0;
            for (var i = 0; i < MONTH_NAMES.length; i++) {
                var month_name = MONTH_NAMES[i];
                if (val.substring(i_val, i_val + month_name.length).toLowerCase() == month_name.toLowerCase()) {
                    if (token == "MMM" || (token == "NNN" && i > 11)) {
                        month = i + 1;
                        if (month > 12) { month -= 12; }
                        i_val += month_name.length;
                        break;
                    }
                }
            }
            if ((month < 1) || (month > 12)) { return 0; }
        }
        else if (token == "EE" || token == "E") {
            for (var i = 0; i < DAY_NAMES.length; i++) {
                var day_name = DAY_NAMES[i];
                if (val.substring(i_val, i_val + day_name.length).toLowerCase() == day_name.toLowerCase()) {
                    i_val += day_name.length;
                    break;
                }
            }
        }
        else if (token == "MM" || token == "M") {
            month = _getInt(val, i_val, token.length, 2);
            if (month == null || (month < 1) || (month > 12)) { return 0; }
            i_val += month.length;
        }
        else if (token == "dd" || token == "d") {
            date = _getInt(val, i_val, token.length, 2);
            if (date == null || (date < 1) || (date > 31)) { return 0; }
            i_val += date.length;
        }
        else if (token == "hh" || token == "h") {
            hh = _getInt(val, i_val, token.length, 2);
            if (hh == null || (hh < 1) || (hh > 12)) { return 0; }
            i_val += hh.length;
        }
        else if (token == "HH" || token == "H") {
            hh = _getInt(val, i_val, token.length, 2);
            if (hh == null || (hh < 0) || (hh > 23)) { return 0; }
            i_val += hh.length;
        }
        else if (token == "KK" || token == "K") {
            hh = _getInt(val, i_val, token.length, 2);
            if (hh == null || (hh < 0) || (hh > 11)) { return 0; }
            i_val += hh.length;
        }
        else if (token == "kk" || token == "k") {
            hh = _getInt(val, i_val, token.length, 2);
            if (hh == null || (hh < 1) || (hh > 24)) { return 0; }
            i_val += hh.length; hh--;
        }
        else if (token == "mm" || token == "m") {
            mm = _getInt(val, i_val, token.length, 2);
            if (mm == null || (mm < 0) || (mm > 59)) { return 0; }
            i_val += mm.length;
        }
        else if (token == "ss" || token == "s") {
            ss = _getInt(val, i_val, token.length, 2);
            if (ss == null || (ss < 0) || (ss > 59)) { return 0; }
            i_val += ss.length;
        }
        else if (token == "a") {
            if (val.substring(i_val, i_val + 2).toLowerCase() == "am") { ampm = "AM"; }
            else if (val.substring(i_val, i_val + 2).toLowerCase() == "pm") { ampm = "PM"; }
            else { return 0; }
            i_val += 2;
        }
        else {
            if (val.substring(i_val, i_val + token.length) != token) { return 0; }
            else { i_val += token.length; }
        }
    }
    // If there are any trailing characters left in the value, it doesn't match
    if (i_val != val.length) { return 0; }
    // Is date valid for month?
    if (month == 2) {
        // Check for leap year
        if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) { // leap year
            if (date > 29) { return 0; }
        }
        else { if (date > 28) { return 0; } }
    }
    if ((month == 4) || (month == 6) || (month == 9) || (month == 11)) {
        if (date > 30) { return 0; }
    }
    // Correct hours value
    if (hh < 12 && ampm == "PM") { hh = hh - 0 + 12; }
    else if (hh > 11 && ampm == "AM") { hh -= 12; }
    var newdate = new Date(year, month - 1, date, hh, mm, ss);
    //return newdate.getTime();
    return newdate;
}

// ------------------------------------------------------------------
// parseDate( date_string [, prefer_euro_format] )
//
// This function takes a date string and tries to match it to a
// number of possible date formats to get the value. It will try to
// match against the following international formats, in this order:
// y-M-d   MMM d, y   MMM d,y   y-MMM-d   d-MMM-y  MMM d
// M/d/y   M-d-y      M.d.y     MMM-d     M/d      M-d
// d/M/y   d-M-y      d.M.y     d-MMM     d/M      d-M
// A second argument may be passed to instruct the method to search
// for formats like d/M/y (european format) before M/d/y (American).
// Returns a Date object or null if no patterns match.
// ------------------------------------------------------------------
function parseDate(val) {
    var preferEuro = (arguments.length == 2) ? arguments[1] : false;
    generalFormats = new Array('y-M-d', 'MMM d, y', 'MMM d,y', 'y-MMM-d', 'd-MMM-y', 'MMM d');
    monthFirst = new Array('M/d/y', 'M-d-y', 'M.d.y', 'MMM-d', 'M/d', 'M-d');
    dateFirst = new Array('d/M/y', 'd-M-y', 'd.M.y', 'd-MMM', 'd/M', 'd-M');
    var checkList = new Array('generalFormats', preferEuro ? 'dateFirst' : 'monthFirst', preferEuro ? 'monthFirst' : 'dateFirst');
    var d = null;
    for (var i = 0; i < checkList.length; i++) {
        var l = window[checkList[i]];
        for (var j = 0; j < l.length; j++) {
            d = getDateFromFormat(val, l[j]);
            if (d != 0) { return new Date(d); }
        }
    }
    return null;
}

//remove char
function removeChar(s, c) {
    var r = "";
    for (var i = 0; i < s.length(); i++) {
        if (s.charAt(i) != c) {
            r += s.charAt(i);
        }
    }
    return r;
}
function upperCaseString(obj) {
    if (event.keyCode == 8 || event.keyCode == 37 || event.keyCode == 39 || event.keyCode == 36 || event.keyCode == 35 || event.keyCode == 46) {
        return;
    }
    else {
        obj.value = obj.value.toUpperCase()
    }
}
function genCBO_Year(currentValue, preValue, nextValue) {
    for (i = currentValue - preValue; i <= currentValue + nextValue; i++) {
        document.write("<option value=" + i);
        if (currentValue == i) {
            document.write(" selected=true ");
        }
        document.write(" >" + i + "</option>");
    }
}

function CheckDateOnBlur(obj) {
    if (!isBlank(obj)) {
        if (isValidDate(obj.value) != 0) {
            alert('Ngay ' + obj.value + ' khong hop le. Nhap ngay theo dang dd/MM/yyyy');
            obj.focus();
            return false;

        }
    }
    return true;
}

function doCheckAll(objAll, objSub, iMax) {
    var obj_i;
    for (var i = 0; i < iMax; i++) {
        obj_i = document.getElementById(objSub + i);
        if (obj_i.disabled == false) {
            obj_i.checked = objAll.checked;
        }
    }
}

/*********************************************
****  Kiem tra ngay hop le (dd/mm/yyyy)  *****
*********************************************/
function isValidDate(strDate) {


    var retval = 0
    var aDDMMCCYY
    var dtest
    // Kiem tra dung format    
    if (/^(\d\d?-\d\d?-\d{4})|(\d\d?\/\d\d?\/\d{4})|(\d{8})$/.test(strDate)) {
        if (/\//.test(strDate)) {
            aDDMMCCYY = strDate.split("/");
        }
        else
            if (/-/.test(strDate)) {
                aDDMMCCYY = strDate.split("-");
            }
            else {
                aDDMMCCYY = Array(strDate.substr(0, 2), strDate.substr(2, 2), strDate.substr(4, 4))
            }
        dtest = new Date(aDDMMCCYY[1] + "/" + aDDMMCCYY[0] + "/" + aDDMMCCYY[2]);

        if (aDDMMCCYY[2] >= 1900) {
            if (dtest.getDate() != aDDMMCCYY[0] || dtest.getMonth() + 1 != aDDMMCCYY[1] || dtest.getFullYear() != aDDMMCCYY[2]) {
                retval = 2
            }
        } else {
            retval = 3
        }
    }
    else {
        retval = 1
    }
    return retval
}

/*********************************************
**** Neu du lieu NULL se return True *********
*********************************************/
function isBlank(obj) {
    if (obj.length < 1 || obj.value == "")
        return true;
    else
        return false;
}

