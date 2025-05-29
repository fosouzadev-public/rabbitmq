terraform {
  required_providers {
    rabbitmq = {
      source = "cyrilgdn/rabbitmq"
      version = "1.8.0"
    }
  }
}

provider "rabbitmq" {
  endpoint = "http://localhost:15672"
  username = "admin"
  password = "Abc-123456"
}

resource "rabbitmq_exchange" "exchange_test" {
  name  = "exchange-test"
  vhost = "/"

  settings {
    type        = "direct"
    durable     = true
    auto_delete = false
  }
}

resource "rabbitmq_queue" "queue_test" {
  name  = "queue-test"
  vhost = "/"

  settings {
    durable     = true
    auto_delete = false
    arguments = {
      "x-queue-type" : "classic",
    }
  }
}

resource "rabbitmq_binding" "binding_test" {
  source           = "${rabbitmq_exchange.exchange_test.name}"
  vhost            = "/"
  destination      = "${rabbitmq_queue.queue_test.name}"
  destination_type = "queue"
}