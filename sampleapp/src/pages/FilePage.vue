<template>
  <q-page class>
    <div class="q-ma-lg">Imagine this as being where you show the details of your file.</div>
    <q-card>
      <q-tabs
        v-model="tab"
        dense
        class="text-grey"
        active-color="primary"
        indicator-color="primary"
        align="justify"
        narrow-indicator
      >
        <q-tab name="general" label="General" />
        <q-tab name="messages" label="Messages" />
      </q-tabs>

      <q-separator />

      <q-tab-panels v-model="tab" animated>
        <q-tab-panel name="general">
          <div class="text-h6">Customer: {{customername}}</div>
          <div>Details about the customer go here</div>
        </q-tab-panel>

        <q-tab-panel name="messages">
          <div class="text-h6">Messages</div>
        </q-tab-panel>
      </q-tab-panels>
    </q-card>
  </q-page>
</template>

<script>
export default {
  name: 'File',
  data () {
    return {
      tab: 'general',
      customerid: 1234,
      customername: 'My Customer'
    }
  },
  mounted () {
    const id = 1234
    this.$connection.on('customerupdate', (customerid, customername) => {
      this.$q.notify({
        color: 'positive',
        position: 'top',
        message: 'Update the customer',
        icon: 'check'
      })
      if (customerid === this.customerid.toString()) {
        console.log('update me')
        this.customername = customername
      }
    }
    )
  }
}
</script>
