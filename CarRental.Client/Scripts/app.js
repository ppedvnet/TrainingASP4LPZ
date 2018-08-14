$(document).ready(function () {

	$.ajax({
		url: "http://localhost:62867/api/v1/cars",
		method: "GET"
	})
		.done(function (data) {
			for (var i = 0; i < data.length; i++) {
				$("#cars-container").append(
					"<p>" + data[i].name + "</p>"
				);
			}
		})
		.fail(function (err) {
			console.log(err);
		});

});