$(function () {
    var l = abp.localization.getResource('CRM');

    var editModal = new abp.ModalManager(abp.appPath + 'Products/EditProductModal');
    var dataTable = $('#ProductsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                ebda3.cRM.products.product.getListWithCategory),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items: [
                            {
                                text: l('Edit'),
                                action: function(data) {
                                    editModal.open({ id: data.record.id })
                                }
                            },
                            {
                                text: l('Delete'),
                                confirmMessage: function (data) {
                                    return l('ProductDeletionConfirmationMessage',
                                        data.record.name);
                                },
                                action: function(data) {
                                    ebda3.cRM.products.product
                                        .delete(data.record.id)
                                        .then(function() {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Category'),
                    data: "categoryName",
                    orderable: false
                },
                {
                    title: l('Price'),
                    data: "price"
                },
                {
                    title: l('Stock-State'),
                    data: "stockState",
                    render: function (data) {
                        return l('Enum:stockState.' + data);
                    }

                },
                {
                    title: l('Creation-Time'),
                    data: "creationTime",
                    dataFormat: 'date'
                }

            ]
        })
    );

    var createModal = new abp.ModalManager(abp.appPath + 'Products/CreateProductModal');
    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    $('#NewProductButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    })
});
