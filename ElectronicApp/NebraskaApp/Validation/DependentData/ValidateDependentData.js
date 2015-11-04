function valSubmit()
{
	var rval = true;
	if(document.getElementById("UserWizard1_isSpouse").value == 1)
	{
		rval = validateSpouse();
	}
	if((document.getElementById("UserWizard1_numChildren").value != 0) && (rval == true))
	{
		rval = validateChildren(document.getElementById("UserWizard1_numChildren").value)
	}
	return rval;
}

function validateSpouse()
{
	var rval = true;
	
	if ( !validateRequired(document.getElementById("UserWizard1_spName").value) )
	{
		alert('Please Enter Spouse Name');
        return false; 		
	}
    if (document.getElementById("UserWizard1_spGender").value == "(Select)")
	{
		alert('Please Select Spouse Gender');
		return false;
	}
	if (!validateRequired(document.getElementById("UserWizard1_spHeight").value) && !validateRequired(document.getElementById("UserWizard1_spHeightin").value)) {
        alert("Please enter spouse Height");
        return false;
	}
    if(!validateRequired(document.getElementById("UserWizard1_spWeight").value))
	{
		alert("Please enter spouse weight");
		return false;
	}
    if(!validateDate(document.getElementById("UserWizard1_spDOB").value)) {
        alert("Please enter valid Date of Birth (mm/dd/yyyy) for spouse");
        return false;
    }
    if (!validateSoc(document.getElementById("UserWizard1_spSSN").value)) {
        alert("Please enter valid Soc. Security Number (111-11-1111)");
        return false;
    }
    if(!validateRequired(document.getElementById("UserWizard1_spStudent").value)) {
        alert("Please select a full-time student status for spouse");
        return false;
	}
    if(!validateRequired(document.getElementById("UserWizard1_spMedicare").value)) {
        alert("Please select a medicare enrollment status for spouse");
        return false;
	}
    if(!validateRequired(document.getElementById("UserWizard1_spSS").value)) {
        alert("Please select a SS enrollment status for spouse");
        return false;
	}
	
	return rval;
}

function validateChildren(childCount)
{
	var rval = true;
	var i = 1;
	while( i <= childCount)
	{
		if (!validateRequired(document.getElementById("UserWizard1_ch"+i+"Name").value ))
		{
			alert("Please Enter Child " + i + "\'s Name");
			return false;
		}
		else if (document.getElementById("UserWizard1_ch"+i+"Gender").value == "(Select)")
		{
			
			alert("Please Enter Child " + i + "\'s Gender");
			return false;
		}
		else if (!validateRequired(document.getElementById("UserWizard1_ch"+i+"Height").value) && !validateRequired(document.getElementById("UserWizard1_ch"+i+"Heightin").value)) {
			alert("Please Enter Child " + i + "\'s Height");
			return false;
		}
		else if(!validateRequired(document.getElementById("UserWizard1_ch"+i+"Weight").value))
		{
			alert("Please Enter Child " + i + "\'s Weight");
			return false;
		}
		else if(!validateDate(document.getElementById("UserWizard1_ch"+i+"DOB").value)) {
			alert('Please enter valid Date of Birth (mm/dd/yyyy) for child ' + i);
			return false;
        }
        else if (!validateSoc(document.getElementById("UserWizard1_ch" + i + "SSN").value)) {
            alert("Please enter valid Soc. Security for child " + i +" Number (111-11-1111)");
            return false;
        }
		else if(!validateRequired(document.getElementById("UserWizard1_ch"+i+"Student").value)) {
			alert('Please select a full time student status for child ' + i);
			return false;
		}
		else if(!validateRequired(document.getElementById("UserWizard1_ch"+i+"Medicare").value)) {
			alert('Please select a medicare enrollment status for child ' + i);
			return false;
		}
		else if(!validateRequired(document.getElementById("UserWizard1_ch"+i+"SS").value)) {
			alert('Please select a SS enrollment status for child ' + i);
			return false;
		}
		i = i+1;
	}
	return rval;
}