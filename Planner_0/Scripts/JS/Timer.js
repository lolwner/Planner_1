var bar;

function Start_timer(obj) {

    //Prevent creating another bar below already existing
    //Global variable is necessary
    if (!bar) {
        secs = parseInt(obj.dur_value.value);
        bar = new ProgressBar.Circle();


        timer = setInterval(
        function () {
            secs--;
            if (secs <= 0) {
                return -1;
            } else {
                return secs;
            }
        },
        1000
        );

        //Creating a bar object in html div with id 'container'
        bar = new ProgressBar.Circle(container, {
            color: '#aaa',
            strokeWidth: 4,
            trailWidth: 1,
            duration: parseInt(obj.dur_value.value) * 1000, //Time to count
            text: {
                autoStyleContainer: false
            },
            from: { color: '#ffc933', width: 4 },
            to: { color: '#ff2400', width: 4 },
            step: function (state, circle) {
                circle.path.setAttribute('stroke', state.color);
                circle.path.setAttribute('stroke-width', state.width);
                circle.setText(secs);
                if (secs < 0) {
                    circle.stop();
                    circle.setText("Done");
                }
            }
        });

        bar.text.style.fontFamily = '"Raleway", Helvetica, sans-serif';
        bar.text.style.fontSize = '2rem';
        bar.animate(1);
    } 
}

