
function VotePreparationAsync(images){
        var datas = [];
        var data = {};
        for(var i = 0; i < images.length; i++){
        data.url = images[i].url;
        data.id = images[i].id;
        data.voteNb = 0;
        datas.push(data);
        };
        console.log(datas[0].url)
}
