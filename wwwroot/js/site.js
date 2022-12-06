function registerUser() {
    debugger;
    var data = {};
    var file = document.getElementById("picture").files;
    data.FirstName = $('#firstName').val();
    data.LastName = $('#lastName').val();
    data.MiddleName = $('#middleName').val();
    data.Address = $('#address').val();
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
				userDetails: userDetails,
				base64: base64
			},
			success: function (result) {
				debugger;
				if (!result.isError) {
					var url = '/Account/Login';
					newSuccessAlert(result.msg, url);
					location.href = result.redirectUrl;
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



function login() {
	debugger;
	var data = {};
	data.Email = $('#email').val();
	data.Password = $('#password').val();
	let loginDetails = JSON.stringify(data);
	reader.onload = function () {
		$.ajax({
			type: 'Post',
			dataType: 'Json',
			url: '/Account/Login',
			data:
			{
				loginDetails: loginDetails,
			},
			success: function (result) {
				debugger;
				if (!result.isError) {
					var url = '/Account/Login';
					newSuccessAlert(result.msg, url);
					location.href = result.redirectUrl;
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








