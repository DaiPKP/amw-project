// JavaScript Document
$(document).ready(function(e) {
	$('select.styled').customSelect();
	$('.slider').bxSlider({
		slideWidth: 180,
		minSlides: 3,
		maxSlides: 3,
		slideMargin: 25,
		pager: false,
		moveSlides: 1,
		auto: true,
		speed: 500
	});

	var index = 0;
	var images = $("div.img_load img");
	var linkhref = $("div.img_load a");
	var caption_p = $("div.left_box_content p");
	var title_p = $("div.left_box_content h3 a");
	var caption = $(".img_load_text p");
	var title = $(".img_load_text h3 a");
	var thumbs = $(".left_box");
	var thumbsimg = $("div.left_box_content a");
	var len = thumbs.length;
	for (i=0; i<len; i++)
	{
		$(thumbsimg[i]).addClass("img-"+i);
	}
	show(index);
	setInterval(sift, 3000);
	
	function sift()
	{
		if (index<(thumbs.length-1)){index+=1;}
		else {index=0}
		show (index);
	}
	
	function show(num)
	{
		var imgsrc = $(thumbsimg[num]).attr("data-id");
		var ahref = $(thumbsimg[num]).attr("href");
		var caption_val = $(caption_p[num]).text();
		var title_val = $(title_p[num]).text();
		images.attr("src",imgsrc);
		linkhref.attr("href",ahref);
		caption.html(caption_val);
		title.html(title_val);
	}

	$(".img_load_text").fadeOut();
	$(".img_load").hover(function(){
		$(".img_load_text").stop().fadeIn();
	},function(){
		$(".img_load_text").stop().fadeOut();
	});
});

		