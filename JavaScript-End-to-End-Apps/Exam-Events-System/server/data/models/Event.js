var mongoose = require('mongoose'),
  REQUIRED = "{PATH} is required",
  config = require('../../config/config'),
  Schema = mongoose.Schema;

var eventSchema = mongoose.Schema({
  user: {
    type: Schema.Types.ObjectId,
    required: REQUIRED,
    ref: "User"
  },
  category: {
    type: Schema.Types.ObjectId,
    required: REQUIRED,
    ref: "Category"
  },
  title: {
    type: String,
    required: REQUIRED
  },
  description: {
    type: String,
    required: REQUIRED
  },
  location: {
    latitude: Number,
    longitude: Number
  },
  type: {
    type: {
      initiative: Schema.Types.ObjectId,
      season: Schema.Types.ObjectId
    },
    required: REQUIRED
  },
  date: {
    type: {},
    default: new Date(),
    required: REQUIRED
  },
  evaluation: {
    type: Number,
    required: REQUIRED
  },
  comments: [String]
});

var Event = mongoose.model('Event', eventSchema);
