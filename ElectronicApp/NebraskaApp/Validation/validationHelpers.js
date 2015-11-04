
    function validateRequired( UserValue )
    {
        var isNotBlank = /\S+/;
        return isNotBlank.test(UserValue);
    }
    
    //Date Validation Functions 
    function validateDate( DateString )
    {
        var ValidFormat = /^\d{1,2}\/\d{1,2}\/\d{4}$/;  //regex matches mm/dd/yyyy
        var ValidFormat1 = /^\d{1,2}-\d{1,2}-\d{4}$/;   //regex matches mm-dd-yyyy
        var rval = false;
        
        if(ValidFormat.test(DateString))  //Date Format in mm/dd/yyyy
        {
            var DateArray = DateString.split("/");
            rval = validateDateHelper(DateArray[0], DateArray[1], DateArray[2]);
        }
        else if(ValidFormat1.test(DateString)) //Date Format in mm-dd-yyyy
        {
            var DateArray = DateString.split("-");
            rval = validateDateHelper(DateArray[0], DateArray[1], DateArray[2]);
        }
        return rval;
    }
    
    function validateDateHelper( Month, Day, Year )
    {
        var rval = false;
        //Javascript Date Object Months are from 0-11
        var objDate = new Date(Year, Month -1, Day); 
        (((objDate.getMonth()+1) == Month)&&(objDate.getDate() == Day)&&(objDate.getFullYear() == Year)) ? rval=true : rval=false;
        return rval;
    }
    
    function validatePhoneNumber(phoneNumber) 
    {
        var ValidFormat = /^(\(\d\d\d\)|\d\d\d-)\s*\d\d\d-\d\d\d\d$/;
        var ValidFormat1 = /^\d\d\d$/;
        var ValidFormat2 = /^\d\d\d$/;
        return ValidFormat.test(phoneNumber);
    }
    
    function validatePhoneNumber1(phoneNumber, phoneNumber1, PhoneNumber2) 
    {
        var ValidFormat =  /^\d\d\d$/;
        var ValidFormat1 = /^\d\d\d$/;
        var ValidFormat2 = /^\d\d\d\d$/;       
        
        return (ValidFormat.test(phoneNumber) && ValidFormat1.test(phoneNumber1) && ValidFormat2.test(PhoneNumber2));
    }
    
    function validateEmail(EmailString)
    {
        var reg = /^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+.)+([a-zA-Z0-9]{2,4})+$/;
        return reg.test(EmailString);
    }
    
    function validateSoc(soc)
    {
        var reg = /^\d\d\d-\d\d-\d\d\d\d/;
        return reg.test(soc);
    }
    
    function validateSoc1(soc, soc1, soc2)
    {
        var ValidFormat =  /^\d\d\d$/;
        var ValidFormat1 = /^\d\d$/;
        var ValidFormat2 = /^\d\d\d\d$/;    
       return (ValidFormat.test(soc) && ValidFormat1.test(soc1) && ValidFormat2.test(soc2));
    }
    function validateZip(ZipCode) {
        var reg = /^(\d{5})(-\d{4})?$/;
        return reg.test(ZipCode);
    }
    
    function validateHeight( heightString )
    {
        var validFormat = /^\d?\d'(\d|1[01])"?$/;
        return validFormat.test(heightString);
    }
    
    