function valSubmit() {

    var numBoxes = new Array(); //These are the indexes of the boxes we are interested in.
    var allBoxes = document.getElementsByTagName("input");
    var rval = true;
    
    for ( i = 0; i < allBoxes.length; i++ ) {
        if ( allBoxes[i].type == "text" ) {
            numBoxes[ numBoxes.length ] = i;
        }
    }
    
    /* Patterns and their relationships:
     *    c_digit_r_digit_txtPersonName     Person's Name       validateRequired
     *    c_digit_r_digit_txtCondition      Condition Type      validateRequired
     *    c_digit_r_digit_txtDiagnosed      Diagnosis Date      validateDate
     *    c_digit_r_digit_txtTreated        Last Treatment Date validateDate
     *    c_digit_r_digit_txtMed            Medications         validateRequired
     *    c_digit_r_digit_txtRecovery       Recovery            validateRequired
     */
    
    var nameTest = /^c_\d+\$r_\d+\$txtPersonName$/;
    var condTest = /^c_\d+\$r_\d+\$txtCondition$/;
    var medTest = /^c_\d+\$r_\d+\$txtMed$/;
    var recvTest = /^c_\d+\$r_\d+\$txtRecovery$/;
    
    var diagTest = /^c_\d+\$r_\d+\$txtDiagnosed$/;
    var tretTest = /^c_\d+\$r_\d+\$txtTreated$/;
    
    var ongoTest = /^c_\d+\$r_\d+\$txtOngoing$/;
    
    for ( i = 0; i < numBoxes.length; i++ ){
        //alert( nameTest.test(allBoxes[ numBoxes[ i ] ].name ) + " nameTest for " + allBoxes[ numBoxes[ i ] ].name);
        if ( nameTest.test(allBoxes[ numBoxes[ i ] ].name ) && !validateRequired(allBoxes[ numBoxes[ i ] ].value) ) {
            alert("Please enter the person's name.");
            allBoxes[ numBoxes[ i ] ].focus();
            rval = false;
            break;
        }
        
        else if ( condTest.test(allBoxes[ numBoxes[ i ] ].name ) && !validateRequired(allBoxes[ numBoxes[ i ] ].value) ) {
            alert("Please enter the name of the condition.");
            allBoxes[ numBoxes[ i ] ].focus();
            rval = false;
            break;
        }
        
        else if ( medTest.test(allBoxes[ numBoxes[ i ] ].name ) && !validateRequired(allBoxes[ numBoxes[ i ] ].value) ) {
            alert("Please enter the treatment type and medication names.");
            allBoxes[ numBoxes[ i ] ].focus();
            rval = false;
            break;
        }
        
        else if ( recvTest.test(allBoxes[ numBoxes[ i ] ].name ) && !validateRequired(allBoxes[ numBoxes[ i ] ].value) ) {
            alert("Please enter degree of recovery.");
            allBoxes[ numBoxes[ i ] ].focus();
            rval = false;
            break;
        }
        
        else if ( diagTest.test(allBoxes[ numBoxes[ i ] ].name ) && !validateRequired(allBoxes[ numBoxes[ i ] ].value) ) {
            alert("Please enter date of diagnosis.");
            allBoxes[ numBoxes[ i ] ].focus();
            rval = false;
            break;
        }
        
        else if ( tretTest.test(allBoxes[ numBoxes[ i ] ].name ) && !validateRequired(allBoxes[ numBoxes[ i ] ].value) ) {
            alert("Please enter date of last treatment.");
            allBoxes[ numBoxes[ i ] ].focus();
            rval = false;
            break;
        }
    }
    
    
    //Check combo boxes
    if ( rval ) {
        var selects = document.getElementsByTagName("select");
        
        for ( i = 0; i < selects.length; i++ ) {
            if ( ongoTest.test( selects[i].name ) && selects[i].value == "Select" ) {
                alert("Please select whether the medication is ongoing.");
                selects[i].focus();
                rval = false;
                break;
            }
        }
    }
    
    //return false;
    return rval;

}