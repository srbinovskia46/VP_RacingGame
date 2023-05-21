# RacingGame

Во оваа возбудлива 2D игра, вие го контролирате вашиот автомобил и треба да избегнете судир со другите автомобили на патот. 
Играта ја презема својата инспирација од класичните 2D игри од нашето детство.

Вашата цел е да се движите низ различни ленти и да избегнете колизија со противничките автомобили. Соберете што е можно повеќе монети и поставете го вашиот најдобар рекорд.

Дали сте подготвени да ги испробате вашите вештини во возење во оваа тркачка игра полна со носталгија? Ве чекаме на патеката!

Играта се состои од 4 класи и 1 форма:
- AICar - автомобилите кои се препреки
- AICoins - паричките кои ки собира корисникот
- PlayerCar - автомобилот кој го контролира корисникот
- Scene - сцената на преку која се исцртуваат објектите

---
Како пример за функционалноста ќе земеме 2 класи, класата PlayerCar и AICoins.
### PlayerCar

PlayerCar класата го претставува автомобилот кој го контролира корисникот, нејзините променливи се јасно дефинирани и во неа има 5 методи.
* Со помош на методот MoveLeft корисничкиот автомобил се поместува на лево внимавајќи на границата на прозорецот, 
аналогно на ова, методот MoveRight има за задача корисничкиот автомобил да го помести на десно внимавајќи на десната граница на прозорецот.

* Методот Draw го исцртува автомобилот на корисникот. 

* Методот GetBounds ги наоѓа крајните точки на објектот, овој метод ни служи за детекција на колизија помеѓу корисникот и останатите автомобили.

* Методот Reset служи за поставување на автомобилот на корисникот во првобитната положба. Овој метод се повикува доколку дојде до поново започнување на играта.
---
### AICoins



---
Метод кој би го одвоил за пример би бил SpawnAICar.

            int laneCount = 3;
            int laneWidth = ClientSize.Width / laneCount;

            // Generate a random lane index
            int laneIndex = random.Next(0, laneCount);

            // Calculate the X position based on the selected lane
            int laneX = laneIndex * laneWidth + laneWidth / 2;

            // Create a new AI car at the top of the screen
            int carWidth = 50;
            int carHeight = 90;
            int carSpeed = 3;

            // Get a random car image from the Resources folder
            string[] carImages = { 
                "Resources/aiCar1.png",
                "Resources/aiCar2.png",
                "Resources/aiCar3.png",
                "Resources/aiCar4.png",
                "Resources/aiCar5.png" };

            int randomIndex = random.Next(0, carImages.Length);
            Image carImage = Image.FromFile(carImages[randomIndex]);

            // Create the AI car using the car image
            AICar aiCar = new AICar(laneX - carWidth / 2, -carHeight, carWidth, carHeight, carSpeed, carImage);

            // Add the AI car to the scene
            scene.aiCars.Add(aiCar);

Во овој метод најпрво со помош на инстанца од класата Random, случајно избираме во која лента сакаме да се појави автомобил. 
Бидејќи сакаме автомобилот да се појави во средината на лентата соодветно ги пресметуваме координатите на почетното теме. 
Ги иницијализираме димензиите за соодветнот автомобил и потоа повторно со помош на инстанца од класата Random избираме случајна слика од низата carImages за генерираниот автомобил.
Откако ги имаме сите овие информации ги праќаме во конструкторот на инстанца од класата AICar. Потоа таа инстанца ја додаваме на сцената и со тоа ни се генерира автомобил.

---
## Изглед на играта

* Игра

![RacingGameImage](https://github.com/srbinovskia46/VP_RacingGame/assets/108271909/5f168469-f708-4f25-85ce-8f2e6b3d9513)

* Порака при колизија

![RacingGameGameOver](https://github.com/srbinovskia46/VP_RacingGame/assets/108271909/17a2fb9a-1878-400d-bbb5-cbf436fa77c0)

---
Контроли за играта:

    Left Arrow - движење на автомобилот на лево
    Right Arrow - движење на автомобилот на десно
---
Членови на тимот:

    213135 Андреј Србиновски
    213178 Васил Стрезов
