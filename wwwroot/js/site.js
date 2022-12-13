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
	let adminDetails = JSON.stringify(data);
	const reader = new FileReader();
	reader.readAsDataURL(file[0]);
	var base64;
	reader.onload = function () {
		base64 = reader.result;
		$.ajax({
			type: 'Post',
			dataType: 'Json',
			url: '/Account/AdminRegister',
			data:
			{
				adminDetails: adminDetails,
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




//function deleteCynlinderCategory() {
//	var Id = $('#deleteId').val();
//	debugger;
//	$.ajax({
//		type: 'Post',
//		dataType: 'Json',
//		url: '/Admin/DeleteCynlinderCategory',
//		data: {
//			Id: Id
//		},
//		success: function (result) {
//			debugger;
//			if (!result.isError) {
//				var url = '/Admin/CynlinderCategory'
//				successAlertWithRedirect(result.msg, url)
//			}
//			else {
//				errorAlert(result.msg)
//			}
//		},
//		error: function (ex) {
//			errorAlert("Error occured try again");
//		}
//	})
//}












