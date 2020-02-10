
    'use strict';

    var area = document.body,
        areaHeight = window.innerHeight,
        areaWidth = window.innerWidth,
        car = document.createElement('img'),
        text = document.createElement("p"),
        timer = 1000;

    /**
     * Set the attributes for the duck
     **/
    car.src='img/car.png';
    car.id = "car";
    car.style.position ='absolute';
    car.style.width = "100px";
    car.style.height = "50px";
    car.style.left = '10em';
    car.style.top = '4em';
    car.style.transition  = "transform 0.3s";
    car.style.zIndex = 10000;
    car.addEventListener('click', onClick);
    
    text.innerHTML = "Use your ''w'', ''a'', ''s'', ''d'' keys to move the car <br /> Click on the car to move to a random positon";
    text.style.left = "5em";
    text.style.top = "0px";
    text.style.fontSize = "16px";
    text.style.position = "absolute";
    text.style.color = "black";
    text.id = "guide";

    /**
     * Keep track on score.
     */
    function onClick() {
        var newX = Math.floor(Math.random() * (areaWidth-car.width)),
            newY = Math.floor(Math.random() * (areaHeight-car.height));
        car.style.top = newY + "px";
        car.style.left = newX + "px";
    }

    /**
     * A function for displaying the duck in random positions
     **/
    var oldKey = "";
    function moveCar() {
        document.addEventListener("keydown", (e) => {
            switch (e.code) {
                case "KeyW":
                    car.style.top = (car.offsetTop - 15) + 'px';
                    car.style.transform = "rotate(270deg)";
                    if(car.offsetTop < 0) {
                        car.style.top = 0 + "px";
                    }
                    break;
                case "KeyS":
                    car.style.top = (car.offsetTop + 15) + 'px';
                    car.style.transform = "rotate(90deg)";
                    break;
                case "KeyD":
                    car.style.left = (car.offsetLeft + 15) + "px";
                    car.style.transform = "rotate(0deg)";
                    if(car.offsetLeft > areaWidth - car.width) {
                        car.style.left = (areaWidth  - car.width) + "px";
                    }
                    break;
                case "KeyA":
                    car.style.left = (car.offsetLeft - 15) + "px";
                    car.style.transform = "rotate(180deg)";
                    if(car.offsetLeft < 0) {
                        car.style.left = 0 + "px";
                    }
                    break;
            }
        })
    }



    /**
     * The function that triggers the game, uses an time interval in milliseconds
     **/
    function addCar() {
        area.append(car);
        area.append(text);
    }
    /**
     * Start the game
     **/

     var carGame = {addCar: addCar, moveCar: moveCar, car: car};
     carGame.addCar();
     carGame.moveCar();

    console.log('Game is ready!');
