var mongoose = require("mongoose");

var categorySchema = mongoose.Schema({
  name: {
    type: String,
    required: "{PATH} is required",
    unique: true
  }
});

var Category = mongoose.model("Category", categorySchema);
