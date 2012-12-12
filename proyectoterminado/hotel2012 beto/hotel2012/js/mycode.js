$(document).ready(function () {
    $("input[name='tipo']").change(
         function () {

             $.ajax({
                 url: "tipo" + $(this).val(),
                 success: function (data) {
                     $("#contenido").slideUp(500);
                     $("#contenido").html(data);
                     $("#contenido").slideDown(500);
                 }
             });
         });






	    // Uncheck each checkbox on body load
	    $('#all_users .selectit').each(function() {this.checked = false;});
	    $('#selected_users .selectit').each(function() {this.checked = false;});
		
	    $('#all_users .selectit').click(function() {
	        var userid = $(this).val();
	        $('#user' + userid).toggleClass('innertxt_bg');
	    });
		
	    $('#selected_users .selectit').click(function() {
	        var userid = $(this).val();
	        $('#user' + userid).toggleClass('innertxt_bg');
	    });
		
	    $("#move_right").click(function() {
	        var users = $('#selected_users .innertxt2').size();
	        var selected_users = $('#all_users .innertxt_bg').size();
			
	        if (users + selected_users > 5) {
	            alert('You can only chose maximum 5 users.');
	            return;
	        }
			
	        $('#all_users .innertxt_bg').each(function() {
	            var user_id = $(this).attr('userid');
	            $('#select' + user_id).each(function() {this.checked = false;});
				
	            var user_clone = $(this).clone(true);
	            $(user_clone).removeClass('innertxt');
	            $(user_clone).removeClass('innertxt_bg');
	            $(user_clone).addClass('innertxt2');
				
	            $('#selected_users').append(user_clone);
	            $(this).remove();
	        });
	    });
		
	    $("#move_left").click(function() {
	        $('#selected_users .innertxt_bg').each(function() {
	            var user_id = $(this).attr('userid');
	            $('#select' + user_id).each(function() {this.checked = false;});
				
	            var user_clone = $(this).clone(true);
	            $(user_clone).removeClass('innertxt2');
	            $(user_clone).removeClass('innertxt_bg');
	            $(user_clone).addClass('innertxt');
				
	            $('#all_users').append(user_clone);
	            $(this).remove();
	        });
	    });
		
	    $('#view').click(function() {
	        var users = '';
	        $('#selected_users .innertxt2').each(function() {
	            var user_id = $(this).attr('userid');
	            if (users == '') 
	                users += user_id;
	            else
	                users += ',' + user_id;
	        });
	        alert(users);
	    });
	    $('.innertxt').click(function (){
	        var t=$('.innertxtActivo').removeClass("innertxtActivo");
	        $(t).addClass("innertxt");
	        $(t).find(".eliminar").hide();
	        $(t).find('.selectit').each(function () { $(this).hide() });
	        $(this).removeClass("innertxtActivo");
	        $(this).addClass("innertxtActivo");
	        $(this).find('.selectit').each(function () { $(this).show()});
	        //alert($(this).find("#eliminar").val());
	        $(this).find(".eliminar").show();//.attr("display", "");
	    });
	    $(".eliminar").click(function () {
	        var con = false;
	        var t = $('.innertxtActivo').find("input:checkbox");
	        
	        t.each(function () {
	            if (this.checked)
	                con = true;
	            //console.log(this.id+"+"+this.checked);
	        });
	        if (con && confirm("estas seguro(a) de eliminar")) {
	            
	            var idu = $(".innertxtActivo").attr("id");

alert(idu);

	            var rol = {};
	            var i = 0;
	           
	            $(".innertxtActivo").find('input:checkbox').each(function () {
	                if (this.checked)
	                    rol[i++] = $(this).val();
	            });
	            var select = $(".innertxtActivo").find('input:checkbox');
	            var dato = {};
	            dato["idu"]=idu;
	            dato["rol"] = rol;

	            
	            $.ajax({
	                data: dato,
                    dataType:'json',
	                url: "/administracion/eliminarrol/data",
	                success: function (data) {
	                    //alert("ff"+data+"++" );
	                    if (data == true)
	                    {
	                        
	                        //alert($(".innertxtActivo").find('li'));
	                        t.each(function () {

	                            if (this.checked) {
	                                //alert(this.checked + "il_" + this.id);
	                                var x = document.getElementById("il_" + this.id);
	                                //alert("esto" + x);
	                                $(x).fadeOut(800);
	                            }
	                        });

	                        var tx = $('.innertxt:first').find("li");
                            tx.each(function () { 
                                $(this).show(1);
                              //ss  alert("hh" + $(this).attr("id"));
                                $(this).css("display","block");
                            });


	                        /*$(".innertxtActivo ul li").each(function () {
	                            //alert($(this).find(':input').val() + "+++" + $(this).find(':input').attr("checked"));
	                            if ($(this).find(':input').attr("checked")=="checked") {
	                                // alert("hh");
	                                var g=$(this).find(':input');
	                                $(this).fadeOut(800);
	                            }
	                               
	                        });*/
	                    }
	                    $("#rolescontenido").html(data);

	                }
	            });
	        }
	    });
	    $("#agregarrol").click(function () {
	        var t = $('#selected_users').find("input:checkbox");
	        var a={};
	        var i=0;
	        t.each(function () {
	            if (this.checked)
	                a[i++]=this.id;
	        });
	        var idu = $(".innertxtActivo").attr("id");
	        if (idu != null && i > 0) {
	            //alert("asdas");
	            var dato = {};
	            dato["idu"]=idu;
	            dato["rol"] = a;
	            $(".innertxtActivo").find("#rolescontenido").fadeOut(800, function () {
	                $(".innertxtActivo").find("#rolescontenido").html("Cargando...");
	                $(".innertxtActivo").find("#rolescontenido").fadeIn(800, function () {
	                    $.ajax({
	                        data: dato,

	                        url: "/administracion/agregarol",
	                        success: function (data) {
	                            $(".innertxtActivo").find("#rolescontenido").fadeOut(800, function () {
	                                $(".innertxtActivo").find("#rolescontenido").html(data);
	                                $(".innertxtActivo").find("#rolescontenido").fadeIn(800);

	                            });

	                            //

	                        }
	                    });
	                });
	            });
	            
	        }
	    });
	    $("#id_pais").change(function () {
	        var t=$("#id_pais").val()==""?0:$("#id_pais").val();
	        $.ajax({
	            url: "/cliente/cargarciudad/" + t,
	            success: function (data) {
	                $("#ciudad").html(data);
	            }
	        });
                
	    });

	    $("#nuevoServicio_click").click(function(ee){
	        tiposervicio = "create";
	        onNewService(1,ee);
	    } );

	    loadEventsss();
	    $("#nuevohabitacion_click").click(function (ee) {
	        tiposervicio1 = "create";
	        onNewService1(1, ee);
	    });


	    loadEventsss1();
	    

});
function onNewService1(e,ev) {
    ev.preventDefault();
    $("#nuevahabitacion").hide(500);
    $("#nuevahabitacion").load("/habitaciones1/create/e", "", function () { $("#nuevahabitacion").show(500); });
}
function onNewService(e, ev) {
    ev.preventDefault();
    $("#nuevoServicio").hide(500);
    $("#nuevoServicio").load("/servicios/create/e", "", function () { $("#nuevoServicio").show(500); });
}
function loadEventsss() {
    //alert("entra");
    console.debug($("table td #update"));
    $("table td #update").each(function () {
        console.debug("---dddd-> " + $(this));
        $(this).click(function (e) {
            e.preventDefault();
            //alert($(this).attr("val"));
            idService = $(this).attr("val");
            onNewService(2,e);
            tiposervicio = "update";
        })

    });
 
    $("table td #servicioDel").each(function () {
        console.debug("----> " + $(this));
        tiposervicio = "";
        $(this).click(function (e) {
            e.preventDefault();
           // alert($(this).attr("val"));
            if (confirm("esta seguro??")) {
                $.ajax({
                    url: "/servicios/Delete/" + $(this).attr("val"),
                    data: $(this).attr("val"),
                    type: "get",
                    success: function (data) {
                        if (data == "true") {
                            $("#lista").load("/servicios/lista", function () {
                                loadEventsss();
                            });
                            $("#nuevoServicio").hide(500);
                        }
                        else
                            alert("Error:");
                    }
                });
            }
        });
    });
}
function loadEventsss1() {
  //  alert("entra");
    console.debug($("table td #update"));
    $("table td #update").each(function () {
        console.debug("---dddd-> " + $(this));
        $(this).click(function (e) {
            e.preventDefault();
            //alert($(this).attr("val"));
            idService1 = $(this).attr("val");
            onNewService1(2, e);
            tiposervicio1 = "update";
        })

    });
    $("table td #habitacionDel").each(function () {
        console.debug("----> " + $(this));
        tiposervicio1 = "";
        $(this).click(function (e) {
            e.preventDefault();
           // alert($(this).attr("val"));
            if (confirm("esta seguro??")) {
                $.ajax({
                    url: "/habitaciones1/Delete/" + $(this).attr("val"),
                    data: $(this).attr("val"),
                    type: "get",
                    success: function (data) {
                        if (data == "true") {
                            $("#lista").load("/habitaciones1/lista", function () {
                                loadEventsss1();
                            });
                            $("#nuevahabitacion").hide(500);
                        }
                        else
                            alert("Error:");
                    }
                });
            }
        });
    });
}
//OTROSS
var tiposervicio = "";
var idService = 0;
var tiposervicio1 = "";
var idService1 = 0;

