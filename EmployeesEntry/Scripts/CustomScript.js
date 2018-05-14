$("#PresentAddress").addClass("form-control");
$("#ParmanentAddress").addClass("form-control");
$("#DateOfBirth").prop("readonly", true);
$("#JoiningDate").prop("readonly", true);
$("#DateOfBirth").datepicker({ dateFormat: "yy/mm/dd" });
$("#JoiningDate").datepicker({ dateFormat: "yy/mm/dd" });