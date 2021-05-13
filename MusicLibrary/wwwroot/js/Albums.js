function GetPhotoAlbums(id) {
    $.ajax({
        url: "/Albums/AlbumPhotos?id="+id,
        type: 'GET',
        success: function (res) {
            debugger
            for (var photo of res) {

                var html = `
            <div class= "card cardmodify rounded" style=" margin-bottom:10px">
            <div card-body">
                <div style="display:flex; flex-direction: row; justify-content: space-between">
                  <div>
                  <img src=${photo.urlPhoto}>
                  </div>
                  <div>
                  ${photo.title}
                  </div>
                  <button type="button" class="btn btn-info btn-sm" onclick="GetComments(${photo.id})" data-toggle="modal" data-target="#myModal" >Ver comentarios</button>
                </div>  
            </div>
            </div>
                           `;

                $(`#collapse-`+id).append(html);
            }


            $(`#collapse-`+id).collapse()

        }
    });
}

function GetComments(id) {

    $("#bodycomments").empty();

    $.ajax({
        url: "/Albums/PhotoComments?id=" + id,
        type: 'GET',
        success: function (res) {
            for (var comments of res) {

                var html = `
               <div class="card" style="display: flex; justify-content: space-between; flex-direction: row; margin:10px 0px"">
                   <div style="width: 50%; display: flex; flex-direction: column;">
                       <p style="margin: 5px; font-weight: bold">User</p>
                       <p style="margin: 5px; font-weight: bold">Comment</p>
                   </div>
                   <div style="width: 50%;display: flex; flex-direction: column; align-items: flex-end">
                       <p style="margin: 5px">${comments.name}</p>
                       <p style="margin: 5px; width: 100%; overflow-y: hidden">${comments.body}</p>
                   </div>
               </div>`;

                $(`#bodycomments`).append(html);
            }

        }
    });

}