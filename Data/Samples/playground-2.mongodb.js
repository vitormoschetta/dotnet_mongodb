// busca todas as despesas
use('pfmdb');
db.expenses.find({}).pretty();


// busca todas as despesas com tag 'compras'
use('pfmdb');
db.expenses.find({
    tags: 'compras', 
}).pretty();


// busca todas as despesas com tag 'compras' e valor maior que 50
use('pfmdb');
db.expenses.find({
  tags: 'compras',
  value: {
      $gt: 50,
  },
}).pretty();


// busca todas as despesas entre os dias 01/01/2021 e 02/01/2021
use('pfmdb');
db.expenses.find({
    date: {
        $gte: '2021-01-01',
        $lte: '2021-01-02',
    },
}).pretty();


// busca todas as despesas do cartão de crédito Nubank
use('pfmdb');
var creditCard = db.credit_cards.findOne({title: 'Nubank'});
db.expenses.find({
    credit_card_id: creditCard._id,
}).pretty();


// mesma consulta acima, mas excluindo os campos _id, credit_card_id e tags do resultado
// no mongodb usamos os valores 0 para excluir um campo do resultado e 1 para incluir um campo no resultado
use('pfmdb');
var creditCard = db.credit_cards.findOne({title: 'Nubank'});
db.expenses.find(
    { credit_card_id: creditCard._id },
    { _id: 0, credit_card_id: 0, tags: 0 },
).pretty();


// busca todas as despesas do cartão de crédito Nubank usando aggregate e lookup (join)
// dessa forma fazemos uma única consulta ao banco de dados
use('pfmdb');
db.expenses.aggregate([
  {
      $lookup: {
          from: 'credit_cards',
          localField: 'credit_card_id',
          foreignField: '_id',
          as: 'credit_card',
      },
  },
  {
      $unwind: '$credit_card',
  },
  {
      $match: {
          'credit_card.title': 'Nubank',
      },
  },
]).pretty();


// a mesma consulta acima, mas com a clausula $project para incluir apenas os campos title, value, date e credit_card.title no resultado
use('pfmdb');
db.expenses.aggregate([
  {
      $lookup: {
          from: 'credit_cards',
          localField: 'credit_card_id',
          foreignField: '_id',
          as: 'credit_card',
      },
  },
  {
      $unwind: '$credit_card',
  },
  {
      $match: {
          'credit_card.title': 'Nubank',
      },
  },
  {
      $project: {
          '_id': 0,
          'title': 1,
          'value': 1,
          'date': 1,
          'credit_card.title': 1,
      },
  },
]).pretty();


// a mesma consulta acima, mas com a clausula $project usando 0 para excluir campos do resultado
use('pfmdb');
db.expenses.aggregate([
  {
      $lookup: {
          from: 'credit_cards',
          localField: 'credit_card_id',
          foreignField: '_id',
          as: 'credit_card',
      },
  },
  {
      $unwind: '$credit_card',
  },
  {
      $match: {
          'credit_card.title': 'Nubank',
      },
  },
  {
      $project: {
          '_id': 0,
          'credit_card_id': 0,
          'tags': 0,
          'credit_card._id': 0,
          'credit_card.limit': 0,
          'credit_card.user_id': 0,
      },
  },
]).pretty();


// uso da clausula $project: 
// 0 para excluir um campo do resultado
// 1 para incluir um campo no resultado
// não pode usar os dois ao mesmo tempo, com exceção do _id