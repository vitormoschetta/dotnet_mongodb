use('pfmdb');
db.users.insertOne({
    _id: 'johndoe@gmail.com',
    name: 'John Doe',
    email: 'johndoe@gmail.com',
});

db.credit_cards.insertMany([
    {
        _id: 1,
        title: 'Nubank',
        limit: 2000,
        user_id: 'johndoe@gmail.com',
    },
    {
        _id: 2,
        title: 'Mercado Pago',
        limit: 1000,
        user_id: 'johndoe@gmail.com',
    },
]);

db.expenses.insertMany([
    {
        _id: 1,
        title: 'Supermercado',
        value: 100,
        date: '2021-01-01',
        credit_card_id: 1,
        tags: ['compras', 'mercado'],
    },
    {
        _id: 2,
        title: 'Restaurante',
        value: 50,
        date: '2021-01-02',
        credit_card_id: 1,
        tags: ['compras', 'restaurante'],
    },
    {
        _id: 3,
        title: 'Uber',
        value: 20,
        date: '2021-01-03',
        credit_card_id: 2,
        tags: ['transporte'],
    },
]);