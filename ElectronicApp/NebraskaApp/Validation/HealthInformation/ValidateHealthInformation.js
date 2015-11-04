function valSubmit()
{ 
    if(document.getElementById("UserWizard1_Q32").value == "(Select)")
    {
        alert("Please select an answer for Question 32");
        return false;
    }
    if(document.getElementById("UserWizard1_Q33").value == "(Select)")
    {
        alert("Please select an answer for Question 33");
        return false;
    }
    if(document.getElementById("UserWizard1_Q34").value == "(Select)")
    {
        alert("Please select an answer for Question 34");
        return false;
    }
    if(document.getElementById("UserWizard1_Q35").value == "(Select)")
    {
        alert("Please select an answer for Question 35");
        return false;
    }
    if(document.getElementById("UserWizard1_CheckBoxList1_8").checked == true)
    {
        if(!validateRequired(document.getElementById("UserWizard1_txtDueDate").value))
        {
            alert("Please enter pregnancy due date");
            
            return false;
        }
    }
    
    return true;
}