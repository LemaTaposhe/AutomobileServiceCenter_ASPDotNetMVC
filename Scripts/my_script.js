var categories = []
function LoadCategory(element) {
    if (categories.length == 0) {
        $.ajax({
            type: "GET",
            url: '/Appoint/getServiceCategories',
            success: function (data) {
                categories = data;
                renderCategory(element);
            }
        })
    }
    else {
        renderCategory(element);
    }
}
function renderCategory(element) {
    var $ele = $(element);
    $ele.empty()
    $ele.append($('<option/>').val('0').text('Select'));

    $.each(categories, function (i, val) {
        $ele.append($('<option/>').val(val.CategoryId).text(val.categoryName));
    })
}


function LoadService(categoryDD) {
   
        $.ajax({
            type: "GET",
            url: '/Appoint/getServices',
            data: {'categoryId':$(categoryDD).val()},
            success: function (data) {
                
                renderService($(categoryDD).parents('.mycontainer').find('select.service'),data);
            },
            error: function (error) {
                console.log(error)
            }
        })   
}
function renderService(element, data) {
    var $ele = $(element);
    $ele.empty()
    $ele.append($('<option/>').val('0').text('Select'));

    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.ServiceId).text(val.ServiceName));
    })
}

$(document).ready(function () {
    // Image Section
    //var formData = new FormData();
    //formData.append('file', $('#imageupload')[0].file[0]);

    //Add Items
    $("#add").click(function () {
        var isAllvalid = true;
        if ($('#serviceCategory').val() == "0") {
            isAllvalid = false;
            $('#serviceCategory').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#serviceCategory').siblings('span.error').css('visibility', 'hidden');
        }

        //service
        if ($('#service').val() == "0") {
            isAllvalid = false;
            $('#service').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#service').siblings('span.error').css('visibility', 'hidden');
        }

        //Quantity
        if (!$('#quantity').val().trim() != "" && (parseInt($('#quantity').val()) || 0)) {
            isAllValid = false;
            $('#quantity').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#quantity').siblings('span.error').css('visibility', 'hidden');
        }



        //Unite Price
        if (!$('#rate').val().trim() != "" && (!isNaN($('#rate').val().trim()))) {
            isAllValid = false;
            $('#rate').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#rate').siblings('span.error').css('visibility', 'hidden');
        }


        if (isAllvalid) {
            var $newRow = $('#mainrow').clone().removeAttr('id');
            $('.pc', $newRow).val($('#serviceCategory').val());
            $('.service', $newRow).val($('#service').val());
            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');
            $('#serviceCategory, #service, #quantity, #rate, #add', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();

            $('#appointDetailsServices').append($newRow);
            $('#serviceCategory, #service').val('0');
            $('#quantity, #rate').val('');
            $("#chooseServiceError").empty();
        }
    });

    // Remove Item
    $('#appointDetailsServices').on('click', '.remove', function () {
        $(this).parents('tr').remove();
    });

    //place Order
    $('#submit').click(function () {
        var isAllValid = true;
        $('#chooseServiceError').text('');
        var list = []
        var errorItemCount = 0;

        //item add to list
        $('#appointDetailsServices tbody tr').each(function (index, ele) {
            if ($('select.service', this).val() == "0" || (parseInt($('.quantity', this).val()) || 0) == 0 || $('.rate', this).val() == "" || isNaN($('.rate', this).val())) {
                errorItemCount++;
                $(this).addClass('error');
            }
            else {
                var chooseService = {
                    ServiceID: $('select.service', this).val(),
                    Quantity: parseInt($('.quantity', this).val()),
                    Price: parseFloat($('.rate', this).val())
                }
                list.push(chooseService);
                //console.log(list)
            }
        })

        //error count and validation
        if (errorItemCount > 0) {
            $('#chooseServiceError').text(errorItemCount + " Invalid entry in order item list!!!");
            isAllValid = false;
        }
        //No. of Item check
        if (list.length == 0) {
            $('#chooseServiceError').text(" At least one entry is required to order an item!!!");
            isAllValid = false;
            console.log("Hello");
        }
        //date get
        if ($('#appointDate').val().trim() == '') {
            $('#appointDate').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#appointDate').siblings('span.error').css('visibility', 'hidden');
        }

        //order submit
        if (isAllValid) {
            var data = {
                AppointDate: $('#appointDate').val().trim(),
                CustomerName: $('#name').val(),
                Image: $('#imageupload').val().trim(),
               // Terms: $('#bool').is('.checked'),
                AppointDetails: list
            }
            $(this).val('Please Wait................')

            //console.log(AppointDetails)
            console.log(data)

            $.ajax({
                type: "POST",
                url: '/Appoint/Save',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        alert("Order Placed successfully!!!!!!!!!!!")
                        list = [];
                        $('#appointDate,#name,#imageupload,#bool').val('');
                        $('#appointDetailsServices').empty();

                        //parsed order 
                        //window.location = '/Order/List';
                    }
                    else {
                        alert('********ERROR********')
                    }
                    $('#submit').val('Save');
                },
                error: function (error) {
                    console.log(error)
                    $('#submit').val('Save');
                }
            })
        }

    });

});

LoadCategory($('#serviceCategory'));