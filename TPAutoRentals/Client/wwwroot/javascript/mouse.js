function mousealert() {
	alert("You clicked the mouse!");
	}
	document.onmousedown = mousealert;
	
	var link1_obj = document.getElementById("link1");
	link1_obj.onclick = myCustomFunction;