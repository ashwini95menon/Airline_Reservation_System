  function validateDateOfReturn() {

        var doj = document.getElementById('<%=txtDateOfJourney.ClientID %>').value;
        var year = doj.substr(0, 4);
        var month = doj.substr(5, 2);
        var day = doj.substr(8, 2);
        var d = parseInt(day);
        var y = parseInt(year);
        var m = parseInt(month);
        m = m - 1;

        var dor = document.getElementById('<%=txtDateOfReturn.ClientID %>').value;
        var year1 = dor.substr(0, 4);
        var month1 = dor.substr(5, 2);
        var day1 = dor.substr(8, 2);
        var d1 = parseInt(day1);
        var y1 = parseInt(year1);
        var m1 = parseInt(month1);
        m1 = m1 - 1;

        var doj1 = new Date(y, m, d);
        var dor1 = new Date(y1,m1,d1);
        var diff = doj1-dor1;
             
        if ((diff > 0))
            alert("Enter a valid date of return");
    }
