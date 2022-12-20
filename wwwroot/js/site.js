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
	if (file[0] == null || data.FirstName == "" || data.LastName == "" || data.MiddleName == "" || data.Address == "" || data.Email == "" || data.Password == "" || data.ConfirmPassword == "")
	{
		if (file[0] != null)
		{
			document.querySelector("#pictureVDT").style.display = "block";
		}
		else
		{
			document.querySelector("#pictureVDT").style.display = "none";
		}
		if (data.FirstName == "")
		{
			document.querySelector("#firstNameVDT").style.display = "block";
		}
		else
		{
			document.querySelector("#firstNameVDT").style.display = "none";
		}
		if (data.LastName == "")
		{
			document.querySelector("#lastNameVDT").style.display = "block";
		}
		else
		{
			document.querySelector("#lastNameVDT").style.display = "none";
		}
		if (data.MiddleName == "")
		{
			document.querySelector("#middleNameVDT").style.display = "block";
		}
		else
		{
			document.querySelector("#middleNameVDT").style.display = "none";
		}
		if (data.Address == "")
		{
			document.querySelector("#addressVDT").style.display = "block";
		}
		else
		{
			document.querySelector("#addressVDT").style.display = "none";
		}
		if (data.Email == "")
		{
			document.querySelector("#emailVDT").style.display = "block";
		}
		else
		{
			document.querySelector("#emailVDT").style.display = "none";
		}
		if (data.Password == "")
		{
			document.querySelector("#passwordVDT").style.display = "block";
		}
		else
		{
			document.querySelector("#passwordVDT").style.display = "none";
		}
		if (data.ConfirmPassword == "")
		{
			document.querySelector("#confirmPasswordVDT").style.display = "block";
		}
		else
		{
			document.querySelector("#confirmPasswordVDT").style.display = "none";
		}

	}
	else
	{
		document.querySelector("#pictureVDT").style.display = "none";
		document.querySelector("#firstNameVDT").style.display = "none";
		document.querySelector("#lastNameVDT").style.display = "none";
		document.querySelector("#middleNameVDT").style.display = "none";
		document.querySelector("#addressVDT").style.display = "none";
		document.querySelector("#emailVDT").style.display = "none";
		document.querySelector("#passwordVDT").style.display = "none";
		document.querySelector("#confirmPasswordVDT").style.display = "none";
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
						successAlertWithRedirect(result.msg, url);

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

}

function registerAdmin() {
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
	if (file[0] == null || data.FirstName == "" || data.LastName == "" || data.MiddleName == "" || data.Address == "" || data.Email == "" || data.Password == "" || data.ConfirmPassword == "") {
		if (file[0] != null) {
			document.querySelector("#pictureVDT").style.display = "block";
		}
		else {
			document.querySelector("#pictureVDT").style.display = "none";
		}
		if (data.FirstName == "") {
			document.querySelector("#firstNameVDT").style.display = "block";
		}
		else {
			document.querySelector("#firstNameVDT").style.display = "none";
		}
		if (data.LastName == "") {
			document.querySelector("#lastNameVDT").style.display = "block";
		}
		else {
			document.querySelector("#lastNameVDT").style.display = "none";
		}
		if (data.MiddleName == "") {
			document.querySelector("#middleNameVDT").style.display = "block";
		}
		else {
			document.querySelector("#middleNameVDT").style.display = "none";
		}
		if (data.Address == "") {
			document.querySelector("#addressVDT").style.display = "block";
		}
		else {
			document.querySelector("#addressVDT").style.display = "none";
		}
		if (data.Email == "") {
			document.querySelector("#emailVDT").style.display = "block";
		}
		else {
			document.querySelector("#emailVDT").style.display = "none";
		}
		if (data.Password == "") {
			document.querySelector("#passwordVDT").style.display = "block";
		}
		else {
			document.querySelector("#passwordVDT").style.display = "none";
		}
		if (data.ConfirmPassword == "") {
			document.querySelector("#confirmPasswordVDT").style.display = "block";
		}
		else {
			document.querySelector("#confirmPasswordVDT").style.display = "none";
		}
	}
	else {
		document.querySelector("#pictureVDT").style.display = "none";
		document.querySelector("#firstNameVDT").style.display = "none";
		document.querySelector("#lastNameVDT").style.display = "none";
		document.querySelector("#middleNameVDT").style.display = "none";
		document.querySelector("#addressVDT").style.display = "none";
		document.querySelector("#emailVDT").style.display = "none";
		document.querySelector("#passwordVDT").style.display = "none";
		document.querySelector("#confirmPasswordVDT").style.display = "none";
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
						successAlertWithRedirect(result.msg, url);

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

}

function login() {
  debugger;
   var data = {};
   data.Email = $('#email').val();
   data.Password = $('#password').val();
   let loginDetails = JSON.stringify(data);
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
				successAlertWithRedirect(result.msg, result.url);
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

function addCategory() {
	debugger;
	var data = {};
	data.Name = $('#name').val();
	data.Quantity = $('#quantity').val();
	let category = JSON.stringify(data);
	$.ajax({
		type: 'Post',
		dataType: 'Json',
		url: '/Admin/AddCynlinderCategory',
		data:
		{
			category: category,
		},
		success: function (result) {
			debugger;
			if (!result.isError) {
				var url = '/Admin/CynlinderCategory';
				successAlertWithRedirect(result.msg, url);
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

function addCynlinder() {
	debugger;
	var data = {};
	var file = document.getElementById("imageUrl").files;
	data.Name = $('#name').val();
	data.Price = $('#price').val();
	data.CynlinderCategoryId = $('#cynlinderCategoryId').val();
	let gasCynlinder = JSON.stringify(data);
	const reader = new FileReader();
	reader.readAsDataURL(file[0]);
	var base64;
	reader.onload = function () {
		base64 = reader.result;
		$.ajax({
			type: 'Post',
			dataType: 'Json',
			url: '/Admin/AddCynlinder',
			data:
			{
				gasCynlinder: gasCynlinder,
				base64: base64
			},
			success: function (result) {
				debugger;
				if (!result.isError) {
					var url = '/Admin/Cynlinder';
					successAlertWithRedirect(result.msg, url);
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

function customerOrder() {
	debugger;
	var data = {};
	data.ProductName = $('#name').val();
	data.QuantityBought = $('#quantity').val();
	data.AmountPaid = $('#totalamount').val();
	data.CustomerName = $('#customerName').val();
	data.CustomerPhoneNumber = $('#customerPhoneNumber').val();
	let orders = JSON.stringify(data);
	$.ajax({
		type: 'Post',
		dataType: 'Json',
		url: '/CustomerOrder/Ordes',
		data:
		{
			orders: orders,
		},
		success: function (result) {
			debugger;
			if (!result.isError) {
				var url = '/Home/Index';
				successAlertWithRedirect(result.msg, url);
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

function cynlinderCategoryToBeEdited(id) {
	debugger;
	$.ajax({
		type: 'GET',
		url: '/Admin/EditedCynlinderCategory', // we are calling json method
		dataType: 'json',
		data:
		{
			cynlinderCategoryId: id
		},
		success: function (data) {
			debugger;
			if (!data.isError) {
				$('#editName').val(data.data.name);
				$('#editQuantity').val(data.data.quantity);
				$('#editId').val(data.data.id);
			}
		},
		error: function (ex) {
			"Something went wrong, contact support - " + errorAlert(ex);
		}
	});
};

function editCynlinderCategory() {

	debugger;
	var data = {};
	data.Name = $("#editName").val();
	data.Id = $("#editId").val();
	data.Quantity = $("#editQuantity").val();
	let cynlinderss = JSON.stringify(data);
	debugger;
	$.ajax({
		type: 'POST',
		url: '/Admin/EditedCynlinderCategory', // we are calling json method,
		dataType: 'json',
		data:
		{
			cynlinderss: cynlinderss,
		},
		success: function (result) {
			debugger;
			if (!result.isError) {
				var url = "/Admin/CynlinderCategory";
				newSuccessAlert(result.msg, url);
			}
			else {
				errorAlert(result.msg);
			}
		},
		error: function (ex) {
			"Something went wrong, contact support - " + errorAlert(ex);
		}
	});
}

function cynlinderCategoryToBeDeleted(id) {
	debugger;
	$("#deleteId").val(id);
}

function deleteCynlinderCategory() {
	debugger;
	var categoryDetails = {};
	categoryDetails = $("#deleteId").val();
	$.ajax({
		type: 'Post',
		url: "/Admin/DeleteCynlinderCategory",
		dataType: 'Json',
		data:
		{
			categoryId: categoryDetails
		},
		success: function (result) {
			debugger;
			if (!result.isError) {
				debugger;
				var url = "/Admin/CynlinderCategory";
				newSuccessAlert(result.msg, url);

			} else {
				errorAlert(result.msg);
			}
		}
	});
}

function cynlinderToBeEdited(id) {
	debugger;
	$.ajax({
		type: 'GET',
		url: '/Admin/EditedCategory', // we are calling json method
		dataType: 'json',
		data:
		{
			cynlinderId: id
		},
		success: function (data) {
			debugger;
			if (!data.isError) {
				$('#editName').val(data.data.name);
				$('#editPrice').val(data.data.price);
				$('#cynlinderCategoryId').val(data.data.cynlinderCategoryId);
				$('#editImageUrl').val(data.data.editImageUrl);
				$('#editId').val(data.data.id);

			}
		},
		error: function (ex) {
			"Something went wrong, contact support - " + errorAlert(ex);
		}
	});
};

function editCynlinder() {
	debugger;
	var data = {};
	var file = document.getElementById("editImageUrl").files;
	data.Name = $("#editName").val();
	data.CynlinderCategoryId = $('#cynlinderCategoryId').val();
	data.Id = $("#editId").val();
	data.Price = $("#editPrice").val();
	let cynlindersss = JSON.stringify(data);
	const reader = new FileReader();
	reader.readAsDataURL(file[0]);
	var base64;
	reader.onload = function () {
		base64 = reader.result;
		debugger;
		$.ajax({
			type: 'POST',
			url: '/Admin/EditedCynlinders', // we are calling json method,
			dataType: 'json',
			data:
			{
				cynlindersss: cynlindersss,
				base64: base64

			},
			success: function (result) {
				debugger;
				if (!result.isError) {
					var url = "/Admin/Cynlinder";
					newSuccessAlert(result.msg, url);
				}
				else {
					errorAlert(result.msg);
				}
			},
			error: function (ex) {
				"Something went wrong, contact support - " + errorAlert(ex);
			}
		});
	}
     
}

function cynlinderToBeDeleted(id) {
	debugger;
	$("#deletId").val(id);
}

function deleteCynlinder() {
	debugger;
	var cynlinderDetails = {};
	cynlinderDetails = $("#deletId").val();
	$.ajax({
		type: 'Post',
		url: "/Admin/DeleteCynlinder",
		dataType: 'Json',
		data:
		{
			categorysId: cynlinderDetails
		},
		success: function (result) {
			debugger;
			if (!result.isError) {
				debugger;
				var url = "/Admin/Cynlinder";
				newSuccessAlert(result.msg, url);

			} else {
				errorAlert(result.msg);
			}
		}
	});
}




