<template>
  <q-page class="center">
    <img alt="Quasar logo" src="~assets/quasar-logo-full.svg" />
    <q-separator />
    <q-btn @click="sendmessage">Send It</q-btn>

    <q-card class="q-ma-lg">
      <q-input v-model="customerid" label="Customer ID" />
      <q-input v-model="name" label="Customer Name" />
      <q-btn @click="sendUpdate">Send Update</q-btn>
    </q-card>
  </q-page>
</template>

<script>
export default {
  name: 'PageIndex',
  data () {
    return {
      customerid: 0,
      name: 'Sample'
    }
  },
  mounted () {
    this.$connection.on('messagereceived', (parameter1, parameter2, parameter3) => {
      this.$q.notify({
        color: 'positive',
        position: 'top',
        message: parameter1 + ' ' + parameter2 + ' ' + parameter3,
        icon: 'check'
      })
    })
  },
  methods: {
    sendmessage () {
      this.$connection.invoke('message', 'andrew', 'says', 'hi')
    },
    sendUpdate () {
      this.$connection.invoke('updatecustomer', this.customerid.toString(), this.name.toString())
    }
  }
}
</script>
