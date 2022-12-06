function registerUser() {
    debugger;
    var data = {};
    var file = document.getElementById("picture").files;
    data.FirstName = $('#firstName').val();
    data.LastName = $('#lastName').val();
    data.MiddleName = $('#middleName').val();
    data.Address = $('homeAddress').val();
    data.Email = $('#email').val();
    data.Password = $('#password').val();
    data.ConfirmPassword = $('#confirmPassword').val();
    let userDetails = JSON.stringify(data);
    const reader = new FileReader();
    reader.readAsDataURL(file[0]);
    var base64;
    reader.onload = function () {
        base64 = reader.result;
		$.ajax({
			type: 'Post',
			dataType: 'Json',
			url: '/Account/Register',
			data:
			{
				applicationUserViewModel: userDetails,
				base64: base64
			},
			success: function (result) {
				debugger;
				if (!result.isError) {
					var url = '/Admin/Index';
					newSuccessAlert(result.msg, url);
				}
				else {
					errorAlert(result.msg);
				}
			},
			error: function (ex) {
				errorAlert("Error Occured,try again.");
			}
		});

    }
}








